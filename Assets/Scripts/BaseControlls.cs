using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControlls : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public float Use { get; set; }

    public float Build { get; set; }

    void Awake()
    {
        PlayerController character;

        if(TryGetComponent<PlayerController>(out character))
        {
            character.Controlls = this;
        } else
        {
            print("No CharacterController found");
        }
    }
}
