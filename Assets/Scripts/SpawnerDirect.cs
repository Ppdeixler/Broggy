using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerDirect : MonoBehaviour
{
    public GameObject direitaPrefab;
    public GameObject esquerdaPrefab;
    public GameObject raivaPrefab;
    public GameObject raivaPrefabDireita;
    public GameObject geloPrefab;
    public GameObject geloPrefabDireita;


    public Transform SpawnerEsquerda;

    private int randomNum;
    private int randomNumLado;
    private Vector2 posicaoAtual;
    private Vector2 posicaoNova;
    public GameObject menu;
    private Botao menuScript;
    private Touch[] touch;
    private int i;
    private bool tocando;

    private float cooldownspawnraiva;
    private float cooldownspawngelo;

    private int randomNumRaiva;
    private int randomNumGelo;

    [SerializeField] public static int rdmGelo = 200;
    [SerializeField] public static int rdmRaiva = 200;
    [SerializeField] public static float raivapreset = 5f;
    [SerializeField] public static float coldpreset = 5f;

    private PlayerController pcscript;
    private GameObject player;

    private Timer timerscript;
    private GameObject timerObj;

    void Start()
    {
        menu = GameObject.FindObjectOfType<Botao>().gameObject;
        menuScript = menu.GetComponent<Botao>();
        player = GameObject.Find("Player");
        pcscript = player.GetComponent<PlayerController>();
        cooldownspawnraiva = 0f;
        cooldownspawngelo = 0f;
        timerObj = GameObject.Find("Timer");
        timerscript = timerObj.GetComponent<Timer>();


    }



    void Update()
    {

        Debug.Log(rdmRaiva);

        touch = new Touch[Input.touchCount];

        cooldownspawnraiva -= Time.deltaTime;

        cooldownspawngelo -= Time.deltaTime;

        randomNum = Random.Range(1, 3);

        randomNumRaiva = Random.Range(1, rdmRaiva);

        randomNumGelo = Random.Range(1, rdmGelo);

        if(pcscript.raivaligado == true)
        {
            randomNumRaiva = 2;
        }


    }





    public void spawnar()
    {
        //NORMAL
        if (randomNum == 1 && randomNumRaiva != 1 && randomNumGelo != 1 || randomNum == 1 && cooldownspawnraiva >= 0 || randomNum == 1 && cooldownspawngelo >= 0)
        {
            Instantiate(direitaPrefab, transform.position, Quaternion.identity);
        }

        if (randomNum == 2 && randomNumRaiva != 1  && randomNumGelo != 1 || randomNum == 2 && cooldownspawnraiva >= 0 || randomNum == 2 && cooldownspawngelo >= 0)
        {
            Instantiate(esquerdaPrefab, SpawnerEsquerda.transform.position, Quaternion.identity);
        }
        //RAIVA
        if(randomNum == 2 && randomNumRaiva == 1 && pcscript.raivaligado == false && cooldownspawnraiva <= 0 && cooldownspawngelo <= 0)
        {
            Instantiate(raivaPrefab, SpawnerEsquerda.transform.position, Quaternion.identity);
            cooldownspawnraiva = 15f;
        }

        if (randomNum == 1 && randomNumRaiva == 1 && pcscript.raivaligado == false && cooldownspawnraiva <= 0 && cooldownspawngelo <= 0)
        {
            Instantiate(raivaPrefabDireita, transform.position, Quaternion.identity);
            cooldownspawnraiva = 15f;
        }
        //GELO
        if (randomNum == 2 && randomNumGelo == 1 && timerscript.congelado == false && cooldownspawngelo <= 0 && cooldownspawnraiva <= 0 && pcscript.raivaligado == false)
        {
            Instantiate(geloPrefab, SpawnerEsquerda.transform.position, Quaternion.identity);
            cooldownspawngelo = 15f;
        }

        if (randomNum == 1 && randomNumGelo == 1 && timerscript.congelado == false && cooldownspawngelo <= 0 && cooldownspawnraiva <= 0 && pcscript.raivaligado == false)
        {
            Instantiate(geloPrefabDireita, transform.position, Quaternion.identity);
            cooldownspawngelo = 15f;
        }
    }
}