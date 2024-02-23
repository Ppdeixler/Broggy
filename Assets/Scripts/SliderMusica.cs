using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusica : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private GameObject sliderobject;

    private float audiogeral;
    private float audiogeralmudando;


    void Awake()
    {
        sliderobject = this.gameObject;
        slider = this.GetComponent<Slider>();
        slider.value = AudioManager.volumemusica;
    }

    void Update()
    {
        audiogeral = slider.value;
        AudioManager.volumemusica = slider.value;
    }
}
