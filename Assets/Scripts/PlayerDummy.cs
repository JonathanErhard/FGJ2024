using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the gameObject based on input
        float moveSpeed = 5f;
        float horizontalInput = -Input.GetAxis("Horizontal");
        float verticalInput = -Input.GetAxis("Vertical");

        // Adjust the movement vector for a 45 degree camera angle
        float adjustedHorizontalInput = (horizontalInput + verticalInput) / Mathf.Sqrt(2);
        float adjustedVerticalInput = (verticalInput - horizontalInput) / Mathf.Sqrt(2);

        Vector3 movement = new Vector3(adjustedHorizontalInput, 0f, adjustedVerticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
