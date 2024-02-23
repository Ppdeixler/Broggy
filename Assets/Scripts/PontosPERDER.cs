using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PontosPERDER : MonoBehaviour
{
    [SerializeField] private GameObject pontos;
    private Score pontinhos;
    [SerializeField] private TextMeshProUGUI pontostexto;
    void Start()
    {
        pontinhos = pontos.GetComponent<Score>();
    }


    void Update()
    {
        pontostexto.text = pontinhos.Pontos.ToString();
    }

}
