using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BuildableProducerSo), menuName = "ScriptableObjects/BuildableProducerSo", order = 1)]
public class BuildableProducerSo : BuildableSo
{
    public List<ResourceSo> NeedsResources;
    public ResourceSo ProducesResources;
    public float TimeUntilProductionInSecs = 1f;
}
