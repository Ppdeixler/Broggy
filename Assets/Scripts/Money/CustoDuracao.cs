using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustoDuracao : MonoBehaviour
{

    [SerializeField] public int custodoupgradepowerupduration;
    [SerializeField] private TextMeshProUGUI textcustodoupgradepowerupduration;


    void Update()
    {
        textcustodoupgradepowerupduration.text = custodoupgradepowerupduration.ToString();
    }
}