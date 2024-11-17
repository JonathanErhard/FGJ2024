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

    private bool _addTextSet;

    void Start()
    {
        if (!_addTextSet)
            _textTitle.text = BuildableSo.Title;

        // Generate preview of buildable
        RuntimePreviewGenerator.OrthographicMode = true;
        var texturePreview = RuntimePreviewGenerator.GenerateModelPreview(BuildableSo.Prefab.transform);
        _spriteImage.sprite = Sprite.Create(texturePreview, new Rect(0, 0, texturePreview.width, texturePreview.height), new Vector2(0.5f, 0.5f));
    }

    public void SetAdditionalText(string text)
    {
        _addTextSet = true;
        _textTitle.SetText($"{BuildableSo.Title} ({text})");
    }
}
