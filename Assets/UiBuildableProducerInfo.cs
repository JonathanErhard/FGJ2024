using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBuildableProducerInfo : MonoBehaviour
{
    public BuildableProducer Buildable;
    public Slider SliderProgress;
    public Button ButtonProvideResources;
    public Button ButtonTakeResources;

    void Start()
    {
        Buildable ??= GetComponentInParent<BuildableProducer>();
    }

    void Update()
    {
        SliderProgress.value = Buildable.ProgressInPercent;
    }
}
