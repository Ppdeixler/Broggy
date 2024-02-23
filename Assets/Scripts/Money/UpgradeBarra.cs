using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBarra : MonoBehaviour
{


    [SerializeField] private bool[] barras;
    [SerializeField] private GameObject[] barrasobject;
    [SerializeField] private int teste;

    void Start()
    {
        teste = 0;
        foreach (bool barra in barras)
        {
            if (barra == true)
            {
                SpawnerDirect.rdmGelo -= 10;
            }
        }
    }

    void Update()
    {
        Debug.Log(SpawnerDirect.rdmGelo);
    }
}
