﻿using UnityEngine;

[CreateAssetMenu(fileName = "resource", menuName = "ScriptableObjects/ResourceS", order = 1)]

public class ResourceSo : ScriptableObject
{
    public string Title;
    public Sprite Image;
    public AudioSource SfxCollect;
}