using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTE : MonoBehaviour
{
    private Touch touch;
    private bool tocando = false;

    void Start()
    {
        tocando = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Pega o toque
        if (Input.touchCount > 0 && tocando == false)
        {
            touch = Input.GetTouch(0);
        

        //Verifica se começou o toque
        if (touch.phase == TouchPhase.Began)
        {
            tocando = true;
        }

        //Verifica se terminou o toque
        if (touch.phase == TouchPhase.Ended)
        {
            tocando = false;
        }

        if(tocando == true)
        {
            Debug.Log("roblox");
        }

        }
    }
}
