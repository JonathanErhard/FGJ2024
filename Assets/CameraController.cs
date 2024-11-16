using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = PlayerController.Instance;
        } else
        {
            transform.position = player.transform.position;
        }
    }
}
