using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteSmooth : MonoBehaviour
{
    public Image timerimage;
    [SerializeField] public float tempoatual;

    void Update()
    {
        roblox();

        target -= 0.1f * Time.deltaTime;

    }


    public float target;
    float smoothTime = 1f;
    float yVelocity = 3f;

    void roblox()
    {
        float newPosition = Mathf.Lerp(timerimage.fillAmount, target, Time.deltaTime * smoothTime);
        timerimage.fillAmount = newPosition;
    }

}
