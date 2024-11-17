using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryUiController;

public class CheatInjector : MonoBehaviour
{
    public List<ResourceLoadout> CheatResources = new();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Add some resources
                foreach (var resource in CheatResources)
                    InventoryController.Instance.AddResource(resource.Resource, resource.Amount);
            }

            if (Input.GetKey(KeyCode.F1))
            {
                Time.timeScale = 1;
            }
            if (Input.GetKey(KeyCode.F2))
            {
                Time.timeScale = 2;
            }
        }
    }
}
