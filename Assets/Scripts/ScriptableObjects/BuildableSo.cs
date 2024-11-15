using UnityEngine;

[CreateAssetMenu(fileName = nameof(BuildableSo), menuName = "ScriptableObjects/BuildableSo", order = 1)]
public class BuildableSo : ScriptableObject
{
    public string Title;
    public string Description;
    public Sprite Image;
    public GameObject Prefab;

    class BuildableRequiredResource
    {
        // TODO: Make this ResourceSo
        public string Resource { get; set; }
        public int Amount { get; set; }
    }
}
