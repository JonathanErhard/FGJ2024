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
    public string ActivityMessage = "Active";
    public bool IsWorking { get; protected set; }
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

    void Start()
    {
        _uiInfo = GetComponentInChildren<UiBuildableProducerInfo>();
    }

    private void OnEnable()
    {
        OnStateUpdate.Invoke();
    }

    void Update()
    {
        // stupid fix, don't have time to look for bugs now
        if(_uiInfo == null)
            _uiInfo = GetComponentInChildren<UiBuildableProducerInfo>();

        _uiInfo.ActivityMessage = ActivityMessage;

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
        else if (BuildableSo.NeedsResources.Count == 0)
        {
            ProvideResources();
        }

        CheckUiInfoVisibility();
    }

    public void ProvideResources()
    {
        if (!InventoryController.Instance.HasResources(BuildableSo.NeedsResources))
            return;

        foreach (var resource in BuildableSo.NeedsResources)
            InventoryController.Instance.RemoveResource(resource, 1);

        IsWorking = true;
        OnStateUpdate.Invoke();
    }

    public void TakeResources()
    {
        InventoryController.Instance.AddResource(BuildableSo.ProducesResources, ProducedResources);
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
