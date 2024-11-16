using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this shows the UI, it doesnt shower the UI, UI still stinks after this
public class SimpleUIShower : MonoBehaviour
{   
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject InteractText;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private bool is_active;
    [SerializeField] private bool is_interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        is_interactable = (player.transform.position - this.gameObject.transform.position).magnitude <= maxDistance;

        InteractText.SetActive(is_interactable && !is_active);
        UIPanel.SetActive(is_active);

        if(is_interactable && Input.GetKeyDown(KeyCode.E)) is_active = true;
        if(is_active && Input.GetKeyDown(KeyCode.Escape)) is_active = false;
    }


}
