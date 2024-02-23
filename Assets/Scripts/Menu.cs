using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public GameObject menu;
    [SerializeField] private GameObject upgradesmenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject tutorial;

    [SerializeField] private GameObject player;

    private Animator animsettings;
    private Animator animupgrade;


    void Start()
    {
        animsettings = settings.GetComponent<Animator>();
        animupgrade = upgradesmenu.GetComponent<Animator>();
    }

    public void jogar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void abrirupgrades()
    {
        if(settings.activeSelf == true) { return; }
        upgradesmenu.SetActive(true);
        animupgrade.SetTrigger("smooth");
    }

    public void abrirtutorial()
    {
        if (settings.activeSelf == true) { return; }
        if (upgradesmenu.activeSelf == true) { return; }
        tutorial.SetActive(true);
        player.SetActive(false);
    }

    public void fechartutorial()
    {
        tutorial.SetActive(false);
        player.SetActive(true);
    }

    public void abrircreditos()
    {
        if (settings.activeSelf == true) { return; }
        if (upgradesmenu.activeSelf == true) { return; }
        credits.SetActive(true);
        player.SetActive(false);

    }

    public void fecharcreditos()
    {
        credits.SetActive(false);
        player.SetActive(true);
    }

    public void fecharupgrades()
    {
        upgradesmenu.SetActive(false);
    }

    public void abrirsettings()
    {
        if (upgradesmenu.activeSelf == true) { return; }
        settings.SetActive(true);
        animsettings.SetTrigger("smoothsetting");
    }

    public void fecharsettings()
    {
        settings.SetActive(false);
    }

}
