using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UiUpgrades : MonoBehaviour
{
    public ResourceSo PartsResource;

    public TMPro.TextMeshProUGUI TextAvailableParts;
    public TMPro.TextMeshProUGUI TextUpgradeCost;

    public TMPro.TextMeshProUGUI TextUpgradeSpeed;
    public Button ButtonUpgradeSpeed;
    public TMPro.TextMeshProUGUI TextUpgradeHealth;
    public Button ButtonUpgradeHealth;

    public int Cost = 1;
    public float CostMultiplier { get; private set; }

    void OnEnable()
    {
        ButtonUpgradeHealth.onClick.AddListener(() =>
        {
            if (InventoryController.Instance.RemoveResource(PartsResource, Cost))
            {
                PlayerController.Instance.UpgradeHealth();
                UpdateValues();
            }
        });

        ButtonUpgradeSpeed.onClick.AddListener(() =>
        {
            if (InventoryController.Instance.RemoveResource(PartsResource, Cost))
            {
                PlayerController.Instance.UpgradeSpeed();
                UpdateValues();
            }
        });

        UpdateValues();
    }

    private void UpdateValues()
    {
        TextUpgradeSpeed.text = $"{PlayerController.Instance.MovementSpeed}";
        TextUpgradeHealth.text = $"{PlayerController.Instance.MaxHealth}";

        InventoryController.Instance.ResourcesDict
            .TryGetValue(PartsResource, out var parts);

        TextAvailableParts.text = $"Parts: {parts}";
        TextUpgradeCost.text = $"Upgrade Cost: {Cost}";
    }
}
