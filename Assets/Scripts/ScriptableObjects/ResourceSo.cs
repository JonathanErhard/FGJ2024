using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ressource", menuName = "ScriptableObjects/RessourceSO", order = 1)]
    public class RessourceSo : ScriptableObject
    {
        public string m_name;
        public Sprite m_image;
        public int m_max_number;
    }
}
