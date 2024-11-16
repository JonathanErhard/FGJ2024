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

    public Dictionary<ResourceSo, int> ResourcesDict = new Dictionary<ResourceSo, int>();

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
}
