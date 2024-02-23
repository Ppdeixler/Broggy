using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Botao menuScript;
    Animator animator;
    [SerializeField] private GameObject camerazinha;
    [SerializeField] private GameObject menu;


    void Start()
    {
        animator = camerazinha.GetComponent<Animator>();
        menuScript = menu.GetComponent<Botao>();



    }


    void Update()
    {
        esquerdabatercamera();
        direitabatercamera();
    }



    public void esquerdabatercamera()
    {
        if (Input.GetKeyDown(KeyCode.A) && menuScript.pausado == false)
        {
            animator.ResetTrigger("TremerDireita");
            animator.ResetTrigger("TremerEsquerda");

            animator.SetTrigger("TremerEsquerda");
        }
    }


    public void direitabatercamera()
    {
        if (Input.GetKeyDown(KeyCode.D) && menuScript.pausado == false)
        {
            animator.ResetTrigger("TremerEsquerda");
            animator.ResetTrigger("TremerDireita");

            animator.SetTrigger("TremerDireita");
        }
    }
}
