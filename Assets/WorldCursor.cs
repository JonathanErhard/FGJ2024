using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class WorldCursor : MonoBehaviour
{
    #region singleton region
    public static WorldCursor Instance;
    public WorldCursor()
    {
        Instance = this;
    }
    #endregion

    // TODO: This approach currently only allows same level building
    Plane plane = new Plane(Vector3.up, 0);

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
