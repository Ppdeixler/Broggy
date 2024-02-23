using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CustoCoin : MonoBehaviour
{

    [SerializeField] public int custodoupgradecoindropchance;
    [SerializeField] private TextMeshProUGUI textcustodoupgradecoindropchance;


    void Update()
    {
        textcustodoupgradecoindropchance.text = custodoupgradecoindropchance.ToString();
    }
}
