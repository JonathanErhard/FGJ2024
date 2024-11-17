using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBuildableCrafting : MonoBehaviour
{
    #region singleton region
    public static UiBuildableCrafting Instance;
    public UiBuildableCrafting()
    {
        Instance = this;
    }
    #endregion

    public TMPro.TextMeshProUGUI TextAvailableMaterials;
    public Transform CraftableBuildingsList;
    public Transform InventoryBuildingsList;
    public UiPanelBuildable PrefabBuildablePanel;

    public ResourceSo BuildingMaterialResource;
    public List<BuildableSo> CraftableBuildings = new();

    void OnEnable()
    {
        FillBuildables();
    }

    public void FillBuildables()
    {
        TextAvailableMaterials.text = InventoryController.Instance.ResourcesDict
            .ContainsKey(BuildingMaterialResource) ? 
            InventoryController.Instance.ResourcesDict[BuildingMaterialResource].ToString() +
            " Building Materials"
            : "0 Building Materials";

        foreach (var buttonBuildable in CraftableBuildingsList.GetComponentsInChildren<Button>())
            Destroy(buttonBuildable.gameObject);
        foreach (var buttonBuildable in InventoryBuildingsList.GetComponentsInChildren<Button>())
            Destroy(buttonBuildable.gameObject);

        foreach (var buildable in CraftableBuildings)
        {
            var panel = Instantiate(PrefabBuildablePanel, CraftableBuildingsList);
            panel.BuildableSo = buildable;
            panel.SetAdditionalText($"{buildable.MaterialCost}");

            var button = panel.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                if (InventoryController.Instance.HasResource(BuildingMaterialResource, buildable.MaterialCost))
                {
                    InventoryController.Instance.AddBuildable(buildable);
                    InventoryController.Instance.RemoveResource(BuildingMaterialResource, buildable.MaterialCost);
                    FillBuildables();
                }
                else
                    print("Not enough resources");
            });
        }

        foreach (var invBuildable in InventoryController.Instance.Buildables)
        {
            var panel = Instantiate(PrefabBuildablePanel, InventoryBuildingsList);
            panel.BuildableSo = invBuildable;
        }
    }
}
