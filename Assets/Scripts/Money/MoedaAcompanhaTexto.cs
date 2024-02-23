using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoedaAcompanhaTexto : MonoBehaviour
{

    private CustoChance custo;

    [SerializeField] private RectTransform imagemmoedinha;


    [SerializeField] private GameObject custoobject;

    [SerializeField] private Vector2 posicaoum;
    [SerializeField] private Vector2 posicaodois;


    void Start()
    {
        custo = custoobject.GetComponent<CustoChance>();
    }

    void Update()
    {
        colocatextodolado();
    }


    void colocatextodolado()
    {
        if(custo.custodoupgradepowerupchance > 99)
        {
            imagemmoedinha.anchoredPosition = posicaodois;
        }
        if(custo.custodoupgradepowerupchance < 100)
        {
            imagemmoedinha.anchoredPosition = posicaoum;
        }
    }


}
