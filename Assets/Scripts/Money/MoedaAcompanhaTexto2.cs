using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoedaAcompanhaTexto2 : MonoBehaviour
{

    private CustoDuracao custo;


    [SerializeField] private RectTransform imagemmoedinha;


    [SerializeField] private GameObject custoobject;

    [SerializeField] private Vector2 posicaoum;
    [SerializeField] private Vector2 posicaodois;


    void Start()
    {
        custo = custoobject.GetComponent<CustoDuracao>();
    }

    void Update()
    {
        colocatextodolado();
    }


    void colocatextodolado()
    {
        if (custo.custodoupgradepowerupduration > 99)
        {
            imagemmoedinha.anchoredPosition = posicaodois;
        }
        if (custo.custodoupgradepowerupduration < 100)
        {
            imagemmoedinha.anchoredPosition = posicaoum;
        }
    }
}
