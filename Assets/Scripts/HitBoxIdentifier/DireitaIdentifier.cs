using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireitaIdentifier : MonoBehaviour
{
    public bool temnadireita;

    public GameObject pitchuco;

    void Update()
    {
        //Debug.Log(temnadireita);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Inimigo")
        {
            temnadireita = true;
            pitchuco = other.gameObject;
        }
        else
        {
            temnadireita = false;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        temnadireita = false;
    }


}
