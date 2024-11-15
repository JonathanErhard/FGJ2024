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
        _spriteImage.sprite = BuildableSo.Image;
    }
}
