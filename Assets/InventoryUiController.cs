using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUiController : MonoBehaviour
{
    public Transform ResourcesList;
    public UiPanelResource PrefabResourcePanel;

    public List<ResourceSo> DebugStartResources = new();

    void Start()
    {
        foreach (var resource in DebugStartResources)
            InventoryController.Instance.AddResource(resource, 10);

        InventoryController.Instance.OnStateUpdate.AddListener(UpdateInventoryUi);
        UpdateInventoryUi();
    }

    public void UpdateInventoryUi()
    {
        print($"Redrawing {InventoryController.Instance.ResourcesDict.Count} resources");

        foreach(var panelResource in ResourcesList.GetComponentsInChildren<UiPanelResource>())
            Destroy(panelResource.gameObject);
        

        foreach (var resourceKeyVal in InventoryController.Instance.ResourcesDict)
        {
            var panel = Instantiate(PrefabResourcePanel, ResourcesList);
            panel.ResourceSo = resourceKeyVal.Key;
            panel.Amount = resourceKeyVal.Value;

            var button = panel.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {

            });
        }
    }
}