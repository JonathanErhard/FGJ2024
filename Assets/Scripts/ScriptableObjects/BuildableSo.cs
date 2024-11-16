using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BuildableSo), menuName = "ScriptableObjects/BuildableSo", order = 1)]
public class BuildableSo : ScriptableObject
{
    public string Title;
    public string Description;
    public GameObject Prefab;
    public List<BuildableRequiredResource> RequiredResources;

    public class BuildableRequiredResource
    {
        // TODO: Make this ResourceSo
        public string Resource { get; set; }
        public int Amount { get; set; }
    }
}
