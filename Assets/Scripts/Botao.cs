using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    public GameObject painelSettings;
    public GameObject painel;
    public GameObject botaopause;
    public GameObject painelretry;
    public GameObject painelconquista;
    public bool pausado;

    public Animator animperder;
    public Animator animpause;
    public Animator animsettings;

    public static bool perdido;

    public PlayerController playerscript;

    [SerializeField] private GameObject player;

    void Start()
    {
        playerscript = player.GetComponent<PlayerController>();
        painel.SetActive(false);
        pausado = false;
        animpause = painel.GetComponent<Animator>();
        if(painelretry.gameObject != null)
        {
            animperder = painelretry.GetComponent<Animator>();
        }

        animsettings = painelSettings.GetComponent<Animator>();
    }

    public void perderogameanim()
    {
        animperder.SetTrigger("perdeugame");
    }

    public void pausar()
    {
        if (playerscript.raivaligado == true)
            return;

        if(perdido == true)
        {
            return;
        }

        animpause.SetTrigger("perdeugame");
        painel.SetActive(true);
        animpause.SetTrigger("perdeugame");
        botaopause.SetActive(false);
        //Time.timeScale = 0f;
        pausado = true;
    }

    public void despausar()
    {
        painel.SetActive(false);
        botaopause.SetActive(true);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void backtomenu()
    {
        Time.timeScale = 1f;
        pausado = false;
        perdido = false;
        SceneManager.LoadScene("Menu");
    }

    public void abrirachievements()
    {
        painelretry.SetActive(false);
        
        painel.SetActive(false);
        
        painelSettings.SetActive(false);

        painelconquista.SetActive(true);
        animsettings.SetTrigger("perdeugame");
    }

    public void settings()
    {
        if (painelretry.gameObject != null)
        {
            painelretry.SetActive(false);
        }
        painel.SetActive(false);
        painelSettings.SetActive(true);
        animsettings.SetTrigger("perdeugame");
    }

    public void achievementsquit()
    {
        if (Botao.perdido == true)
        {
            if (painelretry.gameObject != null)
            {
                painelretry.SetActive(true);
                animperder.SetTrigger("perdeugame");
            }
            painel.SetActive(false);
            painelSettings.SetActive(false);
        }
        if (perdido == false)
        {
            painel.SetActive(true);
            animpause.SetTrigger("perdeugame");
            painelSettings.SetActive(false);
        }
    }

    public void settingsquit()
    {
        if(Botao.perdido == true)
        {
            if (painelretry.gameObject != null)
            {
                painelretry.SetActive(true);
                animperder.SetTrigger("perdeugame");
            }
            painel.SetActive(false);
            painelSettings.SetActive(false);
        }
        if(perdido == false)
        {
            painel.SetActive(true);
            animpause.SetTrigger("perdeugame");
            painelSettings.SetActive(false);
        }

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
