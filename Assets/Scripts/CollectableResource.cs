using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableResource : MonoBehaviour
{
    InventoryController Inventory;
    ResourceSo RessourceSo;

    void Start()
    {
        //inventory = //TODO
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Inventory.AddResource(RessourceSo, 1))
        {
            Destroy(transform.parent.gameObject);
        }
        //TODO play collection audio
    }
}
