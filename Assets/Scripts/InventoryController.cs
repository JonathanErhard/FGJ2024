using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
public class InventoryController : MonoBehaviour
{
    #region singleton region
    public static InventoryController Instance;
    public InventoryController()
    {
        Instance = this;
    }
    #endregion

    private Dictionary<ResourceSo, int> _resourceDict = new();

    public bool AddResource(ResourceSo resource, int count)
    {
        if (!_resourceDict.ContainsKey(resource))
        {
            _resourceDict.Add(resource, 0);
        }
        int current_count = _resourceDict[resource];
        if (current_count + count > resource.MaxCount)
        {
            return false;
        }
        _resourceDict[resource] = current_count + current_count;
        return true;
    }

    public bool RemoveResource(ResourceSo p_ressource, int p_count)
    {
        if (!_resourceDict.ContainsKey(p_ressource))
        {
            return false;
        }
        int current_count = _resourceDict[p_ressource];
        if (current_count - p_count < 0)
        {
            return false;
        }
        _resourceDict[p_ressource] = current_count - current_count;
        return true;
    }

    public bool HasResources(List<ResourceSo> resources)
    {
        foreach (var resource in resources)
        {
            if (!_resourceDict.ContainsKey(resource) || _resourceDict[resource] < 1)
                return false;
        }
        return true;
    }
    
}