using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{   
    [SerializeField] private GameObject tpTarget;
    [SerializeField] private MeshRenderer render;
    [SerializeField] private GameObject InteractText;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private bool is_interactable;
    [SerializeField] private bool is_inside;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(tpTarget.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        InteractText.SetActive(is_interactable);

        if(is_interactable && Input.GetKeyDown(KeyCode.E)){
            player.transform.position = tpTarget.transform.position;
            render.enabled = is_inside;
            player.GetComponent<PlayerController>().IsInBase = !is_inside;
        }

        is_interactable = (player.transform.position - this.gameObject.transform.position).magnitude <= maxDistance;
    }


}
