using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquerdaIdentifier : MonoBehaviour
{
    public bool temnaesquerda;

    public GameObject pitchuco2;

    void Update()
    {
        //Debug.Log(temnaesquerda);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            temnaesquerda = true;
            pitchuco2 = other.gameObject;
        }
        else
        {
            temnaesquerda = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        temnaesquerda = false;
    }


}
