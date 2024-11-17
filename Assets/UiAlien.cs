using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UiAlien : MonoBehaviour
{
    public Transform FoodResourcesList;
    public TMPro.TextMeshProUGUI TextHunger;
    public UiPanelResource PrefabResourcePanel;

    // Resource + how nutritious it is
    public List<ResourceNutrition> NutritionTable = new();

    // necessary because Inspector won't take Dictionaries
    [Serializable]
    public class ResourceNutrition
    {
        [SerializeField]
        public ResourceSo Resource;
        [SerializeField]
        public int Nutrititon;
    }

    void OnEnable()
    {
        UpdateInventoryUi();
    }

    void Update()
    {
        TextHunger.text = $"Hunger: {Alien.Instance.Hunger.ToString("F2")}";
    }

    public void UpdateInventoryUi()
    {
        foreach (var panelResource in FoodResourcesList.GetComponentsInChildren<UiPanelResource>())
            Destroy(panelResource.gameObject);

        foreach (var resourceKeyVal in InventoryController.Instance.ResourcesDict
            .Where(resource => NutritionTable.Any(nutr => nutr.Resource == resource.Key)))
        {
            var panel = Instantiate(PrefabResourcePanel, FoodResourcesList);
            panel.ResourceSo = resourceKeyVal.Key;
            panel.Amount = resourceKeyVal.Value;

            // TODO: Currently nutrition is shown instead of amount

            var nutrition = NutritionTable.FirstOrDefault(nutr => nutr.Resource == resourceKeyVal.Key);
            panel.SetAdditionalText($"{nutrition.Nutrititon}");

            var button = panel.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                if (InventoryController.Instance.RemoveResource(resourceKeyVal.Key, 1))
                {
                    Alien.Instance.Feed(nutrition.Nutrititon);
                    UpdateInventoryUi();
                }
            });
        }
    }
}
