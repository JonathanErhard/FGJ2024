using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableProducer : Buildable
{
    private const float PLAYER_TRIGGER_DISTANCE = 7;

    public BuildableProducerSo BuildableSo;
    public float Progress { get; private set; }

    public float ProgressInPercent
    {
        get
        {
            return Progress / BuildableSo.TimeUntilProductionInSecs;
        }
    }

    private UiBuildableProducerInfo _uiInfo;

    void Start()
    {
        _uiInfo = GetComponentInChildren<UiBuildableProducerInfo>();
    }

    void Update()
    {
        if (Progress < BuildableSo.TimeUntilProductionInSecs)
            Progress += Time.deltaTime;
        else
        {
            // TODO: Finish production
            Progress = 0;
        }

        CheckUiInfoVisibility();
    }


    void CheckUiInfoVisibility()
    {
        _uiInfo.gameObject.SetActive(
                PlayerController.GetDistanceToTrans(transform) < PLAYER_TRIGGER_DISTANCE
            );
    }
}
