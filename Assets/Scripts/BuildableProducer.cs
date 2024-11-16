using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BuildableProducer : Buildable
{
    private const float PLAYER_TRIGGER_DISTANCE = 7;

    public BuildableProducerSo BuildableSo;
    public bool IsWorking { get; private set; }
    public float Progress { get; private set; }
    public int ProducedResources { get; private set; }

    public float ProgressInPercent
    {
        get
        {
            return Progress / BuildableSo.TimeUntilProductionInSecs;
        }
    }

    public UnityEvent OnStateUpdate = new();

    private UiBuildableProducerInfo _uiInfo;
    private InventoryController _inventory;

    void Start()
    {
        _uiInfo = GetComponentInChildren<UiBuildableProducerInfo>();
        _inventory = InventoryController.Instance;
    }

    private void OnEnable()
    {
        OnStateUpdate.Invoke();
    }

    void Update()
    {
        if (IsWorking)
        {
            if (Progress < BuildableSo.TimeUntilProductionInSecs)
                Progress += Time.deltaTime;
            else
            {
                ProducedResources++;
                Progress = 0;
                IsWorking = false;
                OnStateUpdate.Invoke();
            }
        }

        CheckUiInfoVisibility();
    }

    public void ProvideResources()
    {

        if (!_inventory.HasResources(BuildableSo.NeedsResources))
            return;

        foreach (var resource in BuildableSo.NeedsResources)
            _inventory.RemoveResource(resource, 1);

        IsWorking = true;
        OnStateUpdate.Invoke();
    }

    public void TakeResources()
    {
        _inventory.AddResource(BuildableSo.ProducesResources, ProducedResources);
        ProducedResources = 0;
        OnStateUpdate.Invoke();
    }

    private void CheckUiInfoVisibility()
    {
        _uiInfo.gameObject.SetActive(
                PlayerController.GetDistanceToTrans(transform) < PLAYER_TRIGGER_DISTANCE
            );
    }
}
