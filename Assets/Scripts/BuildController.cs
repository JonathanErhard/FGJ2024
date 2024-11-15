using System.Collections;
using System.Collections.Generic;
using UnityEditor.Il2Cpp;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    #region singleton region
    public static BuildController Instance { get; private set; }
    public BuildController()
    {
        Instance = this;
    }
    #endregion

    private BuildCursor _cursor;

    void Start()
    {
        _cursor = BuildCursor.Instance;
    }

    public void SetBuildable(BuildableSo buildableSo)
    {
        var buildable = Instantiate(buildableSo.Prefab);
        _cursor.Kill();
        _cursor = buildable.AddComponent<BuildCursor>();
        _cursor.CurrentBuildable = buildableSo;
    }
}
