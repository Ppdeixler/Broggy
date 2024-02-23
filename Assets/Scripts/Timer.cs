using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float tempoatual;
    private float tempodiminuir;
    private float tempomultiplicador;
    private float multiplicadorgeral;
    private float tempo;
    private float intervalo = 0.1f;
    private float tempoDecorrido = 0f;
    public GameObject pontos;
    private Score pontinhos;
    private int scorePonto;
    public Image timerimage;
    public GameObject menu;
    private Botao menuScript;

    private float gelo;
    public bool congelado;
    [SerializeField] private float cooldowngelo;
    [SerializeField] private float cooldownSet;

    [SerializeField] private bool[] dificuldadeBarras;
    [SerializeField] private GameObject[] dificuldadeBarrasObject;

    [SerializeField] private float balanceamentodificuldade;
    private float tempodiminuirdificuldade;

    [SerializeField] private GameObject audioobject;
    private AudioManager audiomanager;


    void Start()
    {
        audiomanager = audioobject.GetComponent<AudioManager>(); 

        //Variaveis timer
        tempoatual = 1;
        tempomultiplicador = 1;
        gelo = 1f;

        //Cooldown
        intervalo = 0.1f;
        tempoDecorrido = 0f;

        //Variaveis dos pontinhos
        pontinhos = pontos.GetComponent<Score>();

        //Variaveis da imagem
        timerimage = GetComponent<Image>();

        //Variaveis pause
        menu = GameObject.FindObjectOfType<Botao>().gameObject;
        menuScript = menu.GetComponent<Botao>();

    }

    void Update()
    {
        if (menuScript.pausado == false && Botao.perdido == false)
        {
            scorePonto = pontinhos.Pontos;
            tempoDecorrido += Time.deltaTime;

            if (tempoDecorrido >= intervalo)
            {
                timer();
                //tempodiminuir = (0.025f + scorePonto * 0.0001f) * gelo;
                //Debug.Log(tempoatual);
                tempoDecorrido = 0f;
            }

            if (tempoatual >= 1f)
            {
                tempoatual = 1f;
            }

            dificuldadecombo();
            float banana = Mathf.Lerp(timerimage.fillAmount, tempoatual, Time.deltaTime * 30f);
            timerimage.fillAmount = banana;

            gelado();

        }
    }



    private void dificuldadecombo()
    {


        if(scorePonto >= 100)
        {
            if (dificuldadeBarras[0] == false)
            {
                audiomanager.Play("skull1");
            }
            dificuldadeBarras[0] = true;
        }
        if (scorePonto >= 200)
        {
            if (dificuldadeBarras[1] == false)
            {
                audiomanager.Play("skull2");
            }
            dificuldadeBarras[1] = true;
        }
        if (scorePonto >= 300)
        {
            if (dificuldadeBarras[2] == false)
            {
                audiomanager.Play("skull3");
            }
            dificuldadeBarras[2] = true;
        }
        if (scorePonto >= 400)
        {
            if (dificuldadeBarras[3] == false)
            {
                audiomanager.Play("skull4");
            }
            dificuldadeBarras[3] = true;
        }
        if (scorePonto >= 500)
        {
            if (dificuldadeBarras[4] == false)
            {
                audiomanager.Play("skull5");
            }
            dificuldadeBarras[4] = true;
        }

        for (int i = 0; i < dificuldadeBarras.Length; i++)
        {
            if (dificuldadeBarras[i] == true)
            {
                dificuldadeBarrasObject[i].SetActive(true);
                tempodiminuirdificuldade = balanceamentodificuldade * i;
            }
            if (dificuldadeBarras[i] == false)
            {
                dificuldadeBarrasObject[i].SetActive(false);
            }
        }
    }


    public void congelar()
    {
        cooldowngelo = SpawnerDirect.coldpreset;
    }

    void gelado()
    {

        if(congelado == true)
        {
            gelo = 0f;

        }
        if(cooldowngelo > 0f)
        {
            congelado = true;
            cooldowngelo -= Time.deltaTime;
        }
        if(congelado == false)
        {
            gelo = 1f;
        }
        if(cooldowngelo <= 0f)
        {
            congelado = false;
        }



    }


    void timer()
    {
        tempoatual -= ((tempodiminuirdificuldade + 0.025f + scorePonto * 0.0001f) * gelo);

        tempo = Time.time;

        multiplicadorgeral = 1f * tempo;

        tempomultiplicador = 1f * multiplicadorgeral;
    }
}