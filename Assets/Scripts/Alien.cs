using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Alien : MonoBehaviour
{


    [SerializeField] private float hunger = 1;

    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.delayedCall(gameObject, 0.2f, alien_movement);
        //LeanTween.moveSplineLocal(this.gameObject, new Vector3[]{Vector3.zero, hunger * Vector3.up, Vector3.zero}, 1.0).setOnCompleteOnStart(true).setRepeat(-1);
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime * 0.01f;
    }
    /*
    void alien_movement(){
        LeanTween.delayedCall(gameObject, 14f, ()=>{
            LeanTween.moveSplineLocal(gameObject, {Vector3.zero, Vector3.Up * hunger, Vector3.zero}, 1);
        }).setOnCompleteOnStart(true).setRepeat(-1);
    }
    */
}
