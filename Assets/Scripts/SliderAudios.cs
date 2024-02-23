using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudios : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private GameObject sliderobject;

    private float audiogeral;
    private float audiogeralmudando;



    void Awake()
    {
        slider.value = AudioManager.volumegeral;
        sliderobject = this.gameObject;
        slider = this.GetComponent<Slider>();
    }

    void Update()
    {
        audiogeral = slider.value;
        AudioManager.volumegeral = slider.value;
    }



}
