using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour
{
    Inventory Inventory;
    RessourceSo RessourceSo;

    void start()
    {
        //inventory = //TODO
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Inventory.add_ressource(RessourceSo, 1))
        {
            Destroy(transform.parent.gameObject);
        }
        //TODO play collection audio
    }
}
