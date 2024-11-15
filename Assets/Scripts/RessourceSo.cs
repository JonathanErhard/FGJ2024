using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ressource", menuName = "ScriptableObjects/RessourceSO", order = 1)]

public class RessourceSo : ScriptableObject
{
    public string m_name;
    public Sprite m_image;
    public int m_max_number;
    public AudioSource Collect_audio; //TODO
}