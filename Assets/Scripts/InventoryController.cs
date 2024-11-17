using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.Events;
public class InventoryController : MonoBehaviour
{
    #region singleton region
    public static InventoryController Instance;
    public InventoryController()
    {
        Instance = this;
    }
    #endregion

    public UnityEvent OnStateUpdate = new UnityEvent();

    public Dictionary<ResourceSo, int> ResourcesDict = new();
    public List<BuildableSo> Buildables = new();

    public void AddBuildable(BuildableSo buildable)
    {
        Buildables.Add(buildable);
        BuildUiController.Instance.FillBuildables();
    }

    public bool RemoveBuildable(BuildableSo buildable)
    {
        if (!Buildables.Contains(buildable))    
            return false;

        Buildables.Remove(buildable);
        BuildUiController.Instance.FillBuildables();
        return true;
    }

    public bool AddResource(ResourceSo resource, int count)
    {
        if (!ResourcesDict.ContainsKey(resource))
        {
            ResourcesDict.Add(resource, count);
        }
        else
        {
            ResourcesDict[resource] += count;
        }

        OnStateUpdate.Invoke();
        return true;
    }

    public bool RemoveResource(ResourceSo resource, int count)
    {
        if (!ResourcesDict.ContainsKey(resource) || ResourcesDict[resource] < count)
        {
            OnStateUpdate.Invoke();
            return false;
        }

        ResourcesDict[resource] -= count;

        if(ResourcesDict[resource] == 0)
            ResourcesDict.Remove(resource);

        OnStateUpdate.Invoke();
        return true;
    }

    public bool HasResources(List<ResourceSo> resources)
    {
        foreach (var resource in resources)
        {
            if (!ResourcesDict.ContainsKey(resource) || ResourcesDict[resource] < 1)
            {
                OnStateUpdate.Invoke();
                return false;
            }
        }
        OnStateUpdate.Invoke();
        return true;
    }

    public bool HasResource(ResourceSo resource, int count)
    {
        if (!ResourcesDict.ContainsKey(resource) || ResourcesDict[resource] < count)
        {
            OnStateUpdate.Invoke();
            return false;
        }

        OnStateUpdate.Invoke();
        return true;
    }
}
