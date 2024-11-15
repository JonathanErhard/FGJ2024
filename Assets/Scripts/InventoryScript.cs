using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    Dictionary<RessourceSO, int> m_ressource_map;

    bool add_ressource(RessourceSO p_ressource, int p_count)
    {
        if (!m_ressource_map.ContainsKey(p_ressource))
        {
            m_ressource_map.Add(p_ressource, 0);
        }
        int current_count = m_ressource_map[p_ressource];
        if (current_count + p_count > p_ressource.m_max_number)
        {
            return false;
        }
        m_ressource_map[p_ressource] = current_count + current_count;
        return true;
    }
    bool remove_ressource(RessourceSO p_ressource, int p_count)
    {
        if (!m_ressource_map.ContainsKey(p_ressource))
        {
            return false;
        }
        int current_count = m_ressource_map[p_ressource];
        if (current_count - p_count < 0)
        {
            return false;
        }
        m_ressource_map[p_ressource] = current_count - current_count;
        return true;
    }
}