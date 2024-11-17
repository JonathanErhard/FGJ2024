using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TerrainUtils;

public class BuildCursor : MonoBehaviour
{
    #region singleton region
    public static BuildCursor Instance;
    public BuildCursor()
    {
        Instance = this;
    }
    #endregion

    public BuildableSo CurrentBuildable;

    // TODO: This approach currently only allows same level building
    Plane plane = new Plane(Vector3.up, 0);

    void Update()
    {
        // Move cursor to mouse position in level
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
            transform.position = ray.GetPoint(distance);

        // Build on click if not over UI
        if(Input.GetMouseButtonDown(0))
            Build();

        if(Input.GetMouseButtonDown(1))
            gameObject.SetActive(false);
    }

    public void Build()
    {
        if (EventSystem.current.IsPointerOverGameObject() || CurrentBuildable == null)
            return;

        Instantiate(CurrentBuildable.Prefab, transform.position, transform.rotation);

        InventoryController.Instance.RemoveBuildable(CurrentBuildable);

        gameObject.SetActive(false);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
