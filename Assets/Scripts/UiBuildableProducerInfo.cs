using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBuildableProducerInfo : MonoBehaviour
{
    public Image PrefabResourceImage;

    public BuildableProducer Buildable;
    public Slider SliderProgress;
    public Button ButtonProvideResources;
    public Button ButtonTakeResources;

    public Transform TransRequiredResources;
    public Image ImageProducesResource;
    public TMPro.TextMeshProUGUI TextProducesResourceTitle;
    public Image ImageReadyResource;
    public TMPro.TextMeshProUGUI TextReadyResourceTitle;

    private BuildableProducerSo _buildableSo;

    void Start()
    {
        Buildable ??= GetComponentInParent<BuildableProducer>();
        _buildableSo = Buildable.BuildableSo;

        foreach (var resource in _buildableSo.NeedsResources)
        {
            var image = Instantiate(PrefabResourceImage, TransRequiredResources);
            image.sprite = resource.Image;
        }

        ImageReadyResource.sprite = ImageProducesResource.sprite = _buildableSo.ProducesResources.Image;
        TextProducesResourceTitle.text = _buildableSo.ProducesResources.Title;

        // Assign button actions
        ButtonProvideResources.onClick.AddListener(() => Buildable.ProvideResources());
        ButtonTakeResources.onClick.AddListener(() => Buildable.TakeResources());

        // Update ui on buildable state update
        Buildable.OnStateUpdate.AddListener(() =>
        {
            ButtonProvideResources.interactable =
                    !Buildable.IsWorking &&
                    InventoryController.Instance.HasResources(_buildableSo.NeedsResources);

            ButtonTakeResources.interactable =
                    Buildable.ProducedResources > 0;
        });
    }

    void Update()
    {
        SliderProgress.value = Buildable.ProgressInPercent;
        TextReadyResourceTitle.text = $"{_buildableSo.ProducesResources.Title} x {Buildable.ProducedResources}";
    }
}
