using UnityEngine;

[CreateAssetMenu(fileName = "resource", menuName = "ScriptableObjects/ResourceS", order = 1)]

public class ResourceSo : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public int MaxCount;
    public AudioSource SfxCollect;
}