    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int vidasextrassetados;


    [SerializeField] private int basechance;
    [SerializeField] private int basechancemoedas;
    [SerializeField] private float baseraivapreset;
    [SerializeField] private float basecoldpreset;

    [SerializeField] private GameObject powerupchancecusto;
    [SerializeField] private GameObject powerupduracaocusto;
    [SerializeField] private GameObject coindropchancecusto;
    [SerializeField] private GameObject vidaextracusto;

    [SerializeField] public bool[] barraspowerup;
    [SerializeField] private GameObject[] barrasobjectpowerup;

    [SerializeField] public bool[] barraspowerupduration;
    [SerializeField] private GameObject[] barrasobjectpowerupduration;

    [SerializeField] public bool[] barrascoindropchance;
    [SerializeField] private GameObject[] barrasobjectcoindropchance;

    [SerializeField] public bool[] barrasvidaextra;
    [SerializeField] private GameObject[] barrasobjectvidaextra;

    [SerializeField] private GameObject moedinhasomg;
    private CoinVariable moedinhasomgscript;

    private CustoChance custoupgradepowerupchance;
    private CustoDuracao custoupgradepowerupduracao;
    private CustoCoin custoupgradecoindropchance;
    private CustoVidaExtra custoupgradevidaextra;

    [SerializeField] private GameObject audioobject;
    private AudioManager audiomanager;

    void Start()
    {
        audiomanager = audioobject.GetComponent<AudioManager>();
        custoupgradepowerupchance = powerupchancecusto.GetComponent<CustoChance>();
        custoupgradepowerupduracao = powerupduracaocusto.GetComponent<CustoDuracao>();
        custoupgradecoindropchance = coindropchancecusto.GetComponent<CustoCoin>();
        custoupgradevidaextra = vidaextracusto.GetComponent<CustoVidaExtra>();
        LoadPlayer();
        LoadCoins();
        moedinhasomgscript = moedinhasomg.GetComponent<CoinVariable>();
        //LoadCoins();
        //managerscript = managergameobject.GetComponent<Manager>();
    }

    void Update()
    {
        Debug.Log(SpawnerDirect.raivapreset);
        upgradepowerup();
        upgradepowerupduration();
        upgradecoindropchance();
        upgradevidaextra();

    }

    public void comprarpowerup()
    {
        for (int i = 0; i < barraspowerup.Length; i++)
        {
            if (barraspowerup[i] == false && CoinVariable.moedas >= custoupgradepowerupchance.custodoupgradepowerupchance)
            {
                audiomanager.Play("upgrade");
                barraspowerup[i] = true;
                CoinVariable.moedas -= custoupgradepowerupchance.custodoupgradepowerupchance;
                custoupgradepowerupchance.custodoupgradepowerupchance += 50;
                SavePlayer();
                SaveCoins();
                break;
            }
        }
    }

    public void comprarpowerupduration()
    {
        for (int i = 0; i < barraspowerupduration.Length; i++)
        {
            if (barraspowerupduration[i] == false && CoinVariable.moedas >= custoupgradepowerupduracao.custodoupgradepowerupduration)
            {
                audiomanager.Play("upgrade");
                barraspowerupduration[i] = true;
                CoinVariable.moedas -= custoupgradepowerupduracao.custodoupgradepowerupduration;
                custoupgradepowerupduracao.custodoupgradepowerupduration += 50;
                SavePlayer();
                SaveCoins();
                break;
            }
        }
    }

    public void comprarcoindropchance()
    {
        for (int i = 0; i < barrascoindropchance.Length; i++)
        {
            if (barrascoindropchance[i] == false && CoinVariable.moedas >= custoupgradecoindropchance.custodoupgradecoindropchance)
            {
                audiomanager.Play("upgrade");
                barrascoindropchance[i] = true;
                CoinVariable.moedas -= custoupgradecoindropchance.custodoupgradecoindropchance;
                custoupgradecoindropchance.custodoupgradecoindropchance += 50;
                SavePlayer();
                SaveCoins();
                break;
            }
        }
    }

    public void comprarvidaextra()
    {
        for (int i = 0; i < barrasvidaextra.Length; i++)
        {
            if (barrasvidaextra[i] == false && CoinVariable.moedas >= custoupgradevidaextra.custodoupgradevidaextra)
            {
                audiomanager.Play("upgrade");
                barrasvidaextra[i] = true;
                CoinVariable.moedas -= custoupgradevidaextra.custodoupgradevidaextra;
                custoupgradevidaextra.custodoupgradevidaextra += 1;
                SavePlayer();
                SaveCoins();
                break;
            }
        }
    }

    void upgradepowerup()
    {
        for (int i = 0; i < barraspowerup.Length; i++)
        {
            if (barraspowerup[i] == true)
            {
                barrasobjectpowerup[i].SetActive(true);

                custoupgradepowerupchance.custodoupgradepowerupchance = 50 * i + 50;


                SpawnerDirect.rdmGelo = basechance - (i * 15);
                SpawnerDirect.rdmRaiva = basechance - (i * 15);
            }

            if (barraspowerup[i] == false)
            {
                barrasobjectpowerup[i].SetActive(false);
            }
        }
    }


    void upgradepowerupduration()
    {
        for (int i = 0; i < barraspowerupduration.Length; i++)
        {
            if (barraspowerupduration[i] == true)
            {
                barrasobjectpowerupduration[i].SetActive(true);

                custoupgradepowerupduracao.custodoupgradepowerupduration = 50 * i + 50;

                SpawnerDirect.raivapreset = baseraivapreset + (i * 0.5f);
                SpawnerDirect.coldpreset = basecoldpreset + (i * 0.5f);
            }

            if (barraspowerupduration[i] == false)
            {
                barrasobjectpowerupduration[i].SetActive(false);
            }
        }
    }

    void upgradecoindropchance()
    {
        for (int i = 0; i < barrascoindropchance.Length; i++)
        {
            if (barrascoindropchance[i] == true)
            {
                barrasobjectcoindropchance[i].SetActive(true);


                PlayerController.variavelChanceMoedas = basechancemoedas - (i * 1);


                custoupgradecoindropchance.custodoupgradecoindropchance = 50 * i + 50;

            }

            if (barrascoindropchance[i] == false)
            {
                barrasobjectcoindropchance[i].SetActive(false);
            }
        }
    }

    void upgradevidaextra()
    {
        for (int i = 0; i < barrasvidaextra.Length; i++)
        {
            if (barrasvidaextra[i] == true)
            {
                barrasobjectvidaextra[i].SetActive(true);

                vidasextrassetados = i;
                Vidas.vida = vidasextrassetados;


                custoupgradevidaextra.custodoupgradevidaextra = 1000 * i + 1000;

            }

            if (barrasvidaextra[i] == false)
            {
                barrasobjectvidaextra[i].SetActive(false);
            }
        }
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void SaveCoins()
    {
        SaveSystem.SaveCoins(moedinhasomgscript);
    }

    public void LoadCoins()
    {
        DadosJogo moedinhas = SaveSystem.LoadCoins();

        CoinVariable.moedas = moedinhas.moedasatuais;

    }

    public void LoadPlayer()
    {

        DadosJogo data = SaveSystem.LoadPlayer();

        for (int i = 0; i < barraspowerup.Length; i++)
        {
            barraspowerup[i] = data.powerupchancecomprado[i];
        }
        for (int i = 0; i < barraspowerupduration.Length; i++)
        {
            barraspowerupduration[i] = data.powerupduracaocomprado[i];
        }
        for (int i = 0; i < barrascoindropchance.Length; i++)
        {
            barrascoindropchance[i] = data.chancedropmoedacomprado[i];
        }
        for (int i = 0; i < barrasvidaextra.Length; i++)
        {
            barrasvidaextra[i] = data.vidaextracomprado[i];
        }


    }



}
