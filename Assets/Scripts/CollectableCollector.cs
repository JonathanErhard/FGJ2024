using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollector : MonoBehaviour
{

    [SerializeField] private GameObject InteractText;
    [SerializeField] private int type = 0; // 0 = Fragment, 1 = Key
    [SerializeField] private int id = 0; //0, 1, 2 or 3
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private bool is_interactable;

    [SerializeField] private TextProcessor p;

    [SerializeField] private GameObject cone;

    private float _startPosY;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosY = cone.transform.position.y;
        Movement();
    }

    private void Movement()
    {
        LeanTween.moveY(cone, _startPosY + 1f, 1f)
            .setFrom(_startPosY)
            .setEaseInOutSine()
            .setLoopPingPong(1)
            .setOnComplete(() => Movement());
    }

    // Update is called once per frame
    void Update()
    {
        is_interactable = (player.transform.position - this.gameObject.transform.position).magnitude <= maxDistance;
        InteractText.SetActive(is_interactable);

        if(is_interactable && Input.GetKeyDown(KeyCode.E)){
            p.setFound(type, id);
            p.SetUI();
            InteractText.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
