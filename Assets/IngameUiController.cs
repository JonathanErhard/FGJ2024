using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUiController : MonoBehaviour
{
    public BuildUiController BuildUi;
    public InventoryUiController InventoryUi;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            BuildUi.gameObject.SetActive(!BuildUi.gameObject.activeSelf);
            InventoryUi.gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryUi.gameObject.SetActive(!InventoryUi.gameObject.activeSelf);
            BuildUi.gameObject.SetActive(false);
        }
    }
}
