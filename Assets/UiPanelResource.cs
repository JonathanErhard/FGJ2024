using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPanelResource : MonoBehaviour
{
    public ResourceSo ResourceSo;
    public int Amount; 

    [SerializeField]
    private TMPro.TextMeshProUGUI _textTitle;
    [SerializeField]
    private Image _spriteImage;

    private bool _addTextSet;

    void Start()
    {
        if (!_addTextSet)
            _textTitle.text = $"{ResourceSo.Title} ({Amount})";
        _spriteImage.sprite = ResourceSo.Image;
    }

    public void SetAdditionalText(string text)
    {
        _addTextSet = true;
        _textTitle.SetText($"{ResourceSo.Title} ({text})");
    }
}
