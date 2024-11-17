using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUiController : MonoBehaviour
{

    public Transform BuildableList;
    public UiPanelBuildable PrefabBuildablePanel;

    void OnEnable()
    {
        FillBuildables();
    }

    public void FillBuildables()
    {
        foreach(var buildable in InventoryController.Instance.Buildables)
        {
            var panel = Instantiate(PrefabBuildablePanel, BuildableList);
            panel.BuildableSo = buildable;

            var button = panel.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                BuildController.Instance.SetBuildable(buildable);
            });
        }
    }
}
