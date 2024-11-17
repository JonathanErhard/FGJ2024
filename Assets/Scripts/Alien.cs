using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    #region singleton region
    public static Alien Instance;
    public Alien()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    public float Hunger { get; private set; } = 1;

    public float Needyness { get; private set; } = 0.01f;

    private float _startPosY;

    [SerializeField] private Slider hungerslider;

    void Start()
    {
        _startPosY = transform.position.y;

        AnimateJump();
    }

    private void AnimateJump()
    {
        LeanTween.moveY(gameObject, _startPosY + 5* Hunger, 2f-1f*Hunger)
            .setFrom(_startPosY)
            .setEaseInOutSine()
            .setLoopPingPong(1)
            .setOnComplete(() => AnimateJump());
    }

    public void Feed(float nutritionValue)
    {
        Hunger += nutritionValue/10;

        if (Hunger > 1)
            Hunger = 1;

        AudioController.Instance.PlayFeedSound();
    }

    void Update()
    {
        Hunger -= Time.deltaTime * Needyness;
        if(Hunger <= 0) Hunger = 0;

        Needyness += Time.deltaTime * 0.00001f;

        hungerslider.value = Hunger;
    }
}
