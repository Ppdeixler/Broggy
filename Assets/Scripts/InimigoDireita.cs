using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InimigoDireita : MonoBehaviour
{
    public GameObject inimigoDireita;
    Vector2 posicaoAtual;
    Vector2 posicaoNova;

    private Botao menuScript;
    private GameObject menu;
    private Touch[] touch;
    private int i;
    private bool tocando = false;

    private PlayerController pc;
    private GameObject player;

    [SerializeField] private Vector3 posicaonaolegal;

    void Start()
    {
        menu = GameObject.FindObjectOfType<Botao>().gameObject;
        menuScript = menu.GetComponent<Botao>();
        //menu = GameObject.FindObjectOfType<Botao>().gameObject;
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (menuScript.pausado == false)
        {
            touch = new Touch[Input.touchCount];

            if (menuScript.pausado == false)
            {


                //for (i = 0; Input.touchCount > i; i++)
                //{
                //    touch[i] = Input.GetTouch(i);

                //    if (touch[i].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && this.transform.position != posicaonaolegal && pc.raivaligado == false )
                //    {
                //        inimigoAndarDireita();
                //    }
                //}

            }
        }
    }





    public void inimigoAndarDireita()
    {


        
            if (menuScript.pausado == false && this.transform.position != posicaonaolegal)
            {
                posicaoAtual = inimigoDireita.transform.position;
                posicaoNova = posicaoAtual += new Vector2(-2f, 0f);
                inimigoDireita.transform.position = posicaoNova;
            }
        
    }
}

