using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustoChance : MonoBehaviour
{


    [SerializeField] public int custodoupgradepowerupchance;
    [SerializeField] private TextMeshProUGUI textcustodoupgradepowerupchance;

    void Update()
    {
        textcustodoupgradepowerupchance.text = custodoupgradepowerupchance.ToString();
    }





}
