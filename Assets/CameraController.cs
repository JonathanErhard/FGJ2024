using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    private Camera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;

        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void SetUpCamera()
    {
        PlayerCamera = GetComponentInChildren<Camera>();
        PlayerCamera.transform.position = new Vector3(-16, 25, -15);
        PlayerCamera.transform.rotation = new Quaternion(0.353553385f, 0.353553385f, -0.146446601f, 0.853553474f);
    }
}
