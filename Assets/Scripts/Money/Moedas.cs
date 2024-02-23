using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moedas : MonoBehaviour
{



    public TextMeshProUGUI textMoedas;


    void Update()
    {
        textMoedas.text = CoinVariable.moedas.ToString();
    }

}
