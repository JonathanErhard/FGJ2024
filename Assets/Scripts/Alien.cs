using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Alien : MonoBehaviour
{
    [SerializeField] private float hunger = 1;

    private float _startPosY;

    void Start()
    {
        _startPosY = transform.position.y;

        AnimateJump();
    }

    private void AnimateJump()
    {
        LeanTween.moveY(gameObject, _startPosY + 5, 1f)
            .setFrom(_startPosY)
            .setEaseInOutSine()
            .setLoopPingPong(1)
            .setOnComplete(() => AnimateJump());
    }

    void Update()
    {
        hunger -= Time.deltaTime * 0.01f;
    }
}
