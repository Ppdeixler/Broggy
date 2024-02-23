using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CustoVidaExtra : MonoBehaviour
{

    [SerializeField] public int custodoupgradevidaextra;
    [SerializeField] private TextMeshProUGUI textcustodoupgradevidaextra;


    void Update()
    {
        textcustodoupgradevidaextra.text = custodoupgradevidaextra.ToString();
    }
}
