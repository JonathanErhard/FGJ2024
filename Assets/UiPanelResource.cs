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

    void Start()
    {
        _textTitle.text = $"{ResourceSo.Title} ({Amount})";
        _spriteImage.sprite = ResourceSo.Image;
    }
}
