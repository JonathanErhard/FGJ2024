using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPanelBuildable : MonoBehaviour
{
    public BuildableSo BuildableSo;

    [SerializeField]
    private TMPro.TextMeshProUGUI _textTitle;
    [SerializeField]
    private Image _spriteImage;

    void Start()
    {
        _textTitle.text = BuildableSo.Title;

        // Generate preview of buildable
        RuntimePreviewGenerator.OrthographicMode = true;
        var texturePreview = RuntimePreviewGenerator.GenerateModelPreview(BuildableSo.Prefab.transform);
        _spriteImage.sprite = Sprite.Create(texturePreview, new Rect(0, 0, texturePreview.width, texturePreview.height), new Vector2(0.5f, 0.5f));
    }
}
