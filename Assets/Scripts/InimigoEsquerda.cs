using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InimigoEsquerda : MonoBehaviour
{
    public GameObject inimigo;
    Vector2 posicaoAtual;
    Vector2 posicaoNova;
    public GameObject menu;
    private Botao menuScript;
    private Touch[] touch;
    private int i;
    private bool tocando = false;
    [SerializeField] private Vector3 posicaonaolegal;
    private PlayerController pc;
    private GameObject player;

    void Update()
    {

        touch = new Touch[Input.touchCount];
        


        if (menuScript.pausado == false)
        {


            //for(i = 0; Input.touchCount > i; i++)
            //{
            //    touch[i] = Input.GetTouch(i);

            //    if (touch[i].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && this.transform.position != posicaonaolegal && pc.raivaligado == false)
            //    {
            //        inimigoAndarDireita();
            //    }
            //}

        }
    }

    void Start()
    {
        menu = GameObject.FindObjectOfType<Botao>().gameObject;
        menuScript = menu.GetComponent<Botao>();
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
    }






    public void inimigoAndarDireita()
    {

        posicaoAtual = inimigo.transform.position;
        posicaoNova = posicaoAtual += new Vector2(2f, 0f);

        
            if (menuScript.pausado == false && this.transform.position != posicaonaolegal)
            {
                inimigo.transform.position = posicaoNova;
            }

        
    }
}
