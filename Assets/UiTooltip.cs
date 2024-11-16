using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTooltip : MonoBehaviour
{
    public bool IsActive = true;

    private Vector3 _min, _max;
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        _min = new Vector3(0, 0, 0);
        _max = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0);
    }

    void Update()
    {
        if (IsActive)
        {
            //get the tooltip position with offset
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y - (rect.rect.height / 2), 0f);
            //clamp it to the screen size so it doesn't go outside
            transform.position = new Vector3(Mathf.Clamp(position.x, _min.x + rect.rect.width / 2, _max.x - rect.rect.width / 2), Mathf.Clamp(position.y, _min.y + rect.rect.height / 2, _max.y - rect.rect.height / 2), transform.position.z);
        }
    }
}
