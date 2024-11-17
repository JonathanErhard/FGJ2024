using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BuildableSo), menuName = "ScriptableObjects/BuildableSo", order = 1)]
public class BuildableSo : ScriptableObject
{
    public string Title;
    public string Description;
    public int MaterialCost = 5;
    public GameObject Prefab;
}
