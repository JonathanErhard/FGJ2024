using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUiController : MonoBehaviour
{
    #region singleton region
    public static BuildUiController Instance;
    public BuildUiController()
    {
        Instance = this;
    }
    #endregion

    public Transform BuildableList;
    public UiPanelBuildable PrefabBuildablePanel;

    void OnEnable()
    {
        FillBuildables();
    }

    public void FillBuildables()
    {
        foreach (var buttonBuildable in BuildableList.GetComponentsInChildren<Button>())
            Destroy(buttonBuildable.gameObject);

        foreach (var buildable in InventoryController.Instance.Buildables)
        {
            var panel = Instantiate(PrefabBuildablePanel, BuildableList);
            panel.BuildableSo = buildable;

            var button = panel.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                gameObject.SetActive(true);
                BuildController.Instance.SetBuildable(buildable);
            });
        }
    }
}
