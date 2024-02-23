using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public int randomNumMoedasChance;

    private AudioManager audiomanager;

    [SerializeField] private GameObject audioobject;

    public static int variavelChanceMoedas;

    public Transform raypoint;
    public float raydistance;

    public GameObject prefabInimigo;
    private InimigoEsquerda inimigoScript;

    private Score pontos;
    public GameObject textoPontos;

    [SerializeField] private CoinVariable moedinhascript;
    [SerializeField] private GameObject moedinhaobjeto;

    public GameObject timerzin;
    [SerializeField] private GameObject bordaTimerzin;
    private Timer timerScript;
    private Image timerzinImage;
    private Image bordaTimerzinImage;

    public bool errou;

    public GameObject timercongelado;
    [SerializeField] private GameObject bordaconegelado;
    private Animator timercongeladoscript;
    private Image congeladoImage;
    private Image bordaCongeladoImage;
    private Timer timercongeladoScript;

    public Sprite spritenormal;
    public Sprite spriteraiva;

    public GameObject menu;
    private Botao menuScript;

    public GameObject particula;

    private bool resscabo;

    Animator animator;

    public GameObject camera;

    private float adicionarTempo;

    private Touch[] touch;

    private DireitaIdentifier dIdentifier;
    private EsquerdaIdentifier eIdentifier;

    [SerializeField] private GameObject esquerdaGameObjectIdentifier;
    [SerializeField] private GameObject direitaGameObjectIdentifier;
    private bool tocando = false;

    private GameObject spawner;
    private SpawnerDirect spawnerscript;

    public bool raivaligado = false;

    public bool tentativa = false;
    private int i;

    private SpriteRenderer spriteRenderer;

    //[SerializeField] private GameObject mosquinhadireita;
    //[SerializeField] private GameObject mosquinhaesquerda;

    private InimigoEsquerda[] andaresquerdascript;
    private InimigoDireita[] andardireitascript;

    private float cooldownraiva;
    [SerializeField] private float cooldownraivaset;

    [SerializeField] private float raivaduracao;

    [SerializeField] private GameObject score;

    [SerializeField] private GameObject moedasaindo;
    private Animator scoreScript;

    private float cooldownress;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audiomanager = audioobject.GetComponent<AudioManager>();
        Botao.perdido = false;
        Vidas.vida = Manager.vidasextrassetados;
        errou = true;
        cooldownraiva = cooldownraivaset;
        inimigoScript = prefabInimigo.GetComponent<InimigoEsquerda>();
        pontos = textoPontos.GetComponent<Score>();
        timerScript = timerzin.GetComponent<Timer>();
        timercongeladoScript = timercongelado.GetComponent<Timer>();
        menuScript = menu.GetComponent<Botao>();
        animator = GetComponent<Animator>();
        adicionarTempo = 0.1f;
        eIdentifier = esquerdaGameObjectIdentifier.GetComponent<EsquerdaIdentifier>();
        dIdentifier = direitaGameObjectIdentifier.GetComponent<DireitaIdentifier>();
        spawner = GameObject.Find("SpawnerDireita");
        spawnerscript = spawner.GetComponent<SpawnerDirect>();
        scoreScript = score.GetComponent<Animator>();
        moedinhascript = moedinhaobjeto.GetComponent<CoinVariable>();
        pegarTimers();
        SaveSystem.SaveCoins(moedinhascript);
        LoadScore();
    }



    void Update()
    {


        perderJogoPorTempo();
        //Debug.Log(raivaligado);
        touch = new Touch[Input.touchCount];

        andardireitascript = FindObjectsOfType<InimigoDireita>();
        andaresquerdascript = FindObjectsOfType<InimigoEsquerda>();

        Debug.Log(Botao.perdido);

        raiva();

        timerQuandoCongelado();

        arrumarbug();

        for (i = 0; i < Input.touchCount; i++)
        {
            
                touch[i] = Input.GetTouch(i);

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && Botao.perdido == false && resscabo == true)
            {
                virarPlayer();
                baterNoInimigo();
                adicionandoTempoPorClique();
            }
        }
    }

    void pegarTimers()
    {
        timerzinImage = timerzin.GetComponent<Image>();
        bordaTimerzinImage = bordaTimerzin.GetComponent<Image>();
        congeladoImage = timercongelado.GetComponent<Image>();
        bordaCongeladoImage = bordaconegelado.GetComponent<Image>();
        timercongeladoscript = timercongelado.GetComponent<Animator>();
    }

    void raiva()
    {
        if (raivaduracao > 0)
        {
            raivaligado = true;
            raivaduracao -= Time.deltaTime;
        }
        if(raivaduracao <= 0)
        {
            raivaligado = false;
        }




        if (raivaligado == true)
        {
            spriteRenderer.sprite = spriteraiva;
            raivaduracao -= Time.deltaTime;
            cooldownraiva -= Time.deltaTime;
            if (cooldownraiva <= 0)
            {
                virarPlayerRaiva();
                baterRaiva();
                adicionandoTempoPorClique();
                cooldownraiva = cooldownraivaset;
            }
        } else
        {
            spriteRenderer.sprite = spritenormal;
        }


    }

    public void powerupRaiva()
    {
        raivaduracao += SpawnerDirect.raivapreset;
    }


    void virarPlayer()
    {
        
            if (touch[i].position.x > Screen.width / 2 && menuScript.pausado == false && touch[i].phase == TouchPhase.Began || raivaligado == true && dIdentifier.temnadireita == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (touch[i].position.x < Screen.width / 2 && menuScript.pausado == false && touch[i].phase == TouchPhase.Began || raivaligado == true && eIdentifier.temnaesquerda == true)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        
    }

    void virarPlayerRaiva()
    {
        if(raivaligado == true && dIdentifier.temnadireita == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (raivaligado == true && eIdentifier.temnaesquerda == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void timerQuandoCongelado()
    {
        if(timerScript.congelado == true)
        {
            congeladoImage.enabled = true;
            bordaCongeladoImage.enabled = true;
            timerzinImage.enabled = false;
            bordaTimerzinImage.enabled = false;
        }

        if (timerScript.congelado == false)
        {
            congeladoImage.enabled = false;
            bordaCongeladoImage.enabled = false;
            timerzinImage.enabled = true;
            bordaTimerzinImage.enabled = true;
        }

    }


    void perder()
    {
        audiomanager.Play("deathsound");
        menuScript.painelretry.SetActive(true);
        menuScript.perderogameanim();
        Botao.perdido = true;
        SaveSystem.SaveCoins(moedinhascript);
        SaveScore();
        AdsManager.falhasanuncio -= 1;
    }

    public void SalvarMoedas()
    {

    }

    void baterNoInimigo()
    {
        //Debug.Log(Vidas.vida);
        RaycastHit2D hit = Physics2D.Raycast(raypoint.position, transform.right, raydistance);

        //HIT DIREITA
            if (touch[i].position.x > Screen.width / 2 && menuScript.pausado == false && touch[i].phase == TouchPhase.Began && raivaligado == false)
            {


                if(hit.collider == null && raivaligado == false && Vidas.vida == 0)
                {
                Vidas.vida = Manager.vidasextrassetados;
                perder();
                errou = false;
            }

                if (hit.collider == null && Vidas.vida >= 1 && dIdentifier.temnadireita == false)
                {

                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
                spawnerscript.spawnar();
                Destroy(eIdentifier.pitchuco2);
                    Vidas.vida -= 1;

                timerScript.congelar();
                timercongeladoScript.congelar();
                cooldownress = 1f;
                audiomanager.Play("ress");


            }

                if (hit.collider != null && hit.collider.gameObject.tag == "Inimigo")
                {
                errou = true;
                    pontos.aumentarPontos();
                    ganharmoedas();
                    Instantiate(particula, hit.collider.gameObject.transform.position, Quaternion.identity);
                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
                Destroy(hit.collider.gameObject);

                    timerScript.tempoatual += adicionarTempo;
                    timercongeladoScript.tempoatual += adicionarTempo;

                    animator.ResetTrigger("Atacando");
                    animator.SetTrigger("Atacando");

                //scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                    scoreScript.SetTrigger("hit");

                    spawnerscript.spawnar();
                audiomanager.Play("nhac");
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Raiva")
            {
                audiomanager.Play("raiva");
                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
                errou = true;
                powerupRaiva();

                pontos.aumentarPontos();
                ganharmoedas();
                Instantiate(particula, new Vector2(-2f, -0.25f), Quaternion.identity);
                Destroy(hit.collider.gameObject);

                timerScript.tempoatual += adicionarTempo;
                timercongeladoScript.tempoatual += adicionarTempo;
                animator.ResetTrigger("Atacando");
                animator.SetTrigger("Atacando");

                scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                scoreScript.SetTrigger("hit");

                spawnerscript.spawnar();
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Gelo")
            {
                audiomanager.Play("congelar");
                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
                errou = true;
                timerScript.congelar();
                timercongeladoScript.congelar();

                pontos.aumentarPontos();
                ganharmoedas();
                Instantiate(particula, new Vector2(-2f, -0.25f), Quaternion.identity);
                Destroy(hit.collider.gameObject);

                timerScript.tempoatual += adicionarTempo;
                timercongeladoScript.tempoatual += adicionarTempo;
                animator.ResetTrigger("Atacando");
                animator.SetTrigger("Atacando");

                //scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                scoreScript.SetTrigger("hit");

                timercongeladoscript.ResetTrigger("congelar");
                timercongeladoscript.SetTrigger("congelar");

                spawnerscript.spawnar();



            }
            //HIT ESQUERDA
        }

            if (touch[i].position.x < Screen.width / 2 && menuScript.pausado == false && touch[i].phase == TouchPhase.Began && raivaligado == false)
            {


            if (hit.collider == null && raivaligado == false && Vidas.vida == 0)
            {
                Vidas.vida = Manager.vidasextrassetados;
                perder();
                errou = false;
            }

            if (hit.collider == null && Vidas.vida >= 1 && eIdentifier.temnaesquerda == false)
            {
                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
                audiomanager.Play("ress");
                timerScript.congelar();
                timercongeladoScript.congelar();
                cooldownress = 1f;

                spawnerscript.spawnar();
                Destroy(dIdentifier.pitchuco);
                Vidas.vida -= 1;

            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Inimigo")
                {
                audiomanager.Play("nhac");
                errou = true;
                pontos.aumentarPontos();
                ganharmoedas();
                Instantiate(particula, new Vector2(-2f, -0.25f), Quaternion.identity);
                    Destroy(hit.collider.gameObject);

                    timerScript.tempoatual += adicionarTempo;
                    timercongeladoScript.tempoatual += adicionarTempo;
                    animator.ResetTrigger("Atacando");
                    animator.SetTrigger("Atacando");

                //scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                scoreScript.SetTrigger("hit");

                spawnerscript.spawnar();
                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Raiva")
            {
                audiomanager.Play("raiva");
                errou = true;

                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }

                powerupRaiva();

                pontos.aumentarPontos();
                ganharmoedas();
                Instantiate(particula, new Vector2(-2f, -0.25f), Quaternion.identity);
                Destroy(hit.collider.gameObject);

                timerScript.tempoatual += adicionarTempo;
                timercongeladoScript.tempoatual += adicionarTempo;
                animator.ResetTrigger("Atacando");
                animator.SetTrigger("Atacando");

                //scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                scoreScript.SetTrigger("hit");

                spawnerscript.spawnar();
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Gelo")
            {
                audiomanager.Play("congelar");
                errou = true;
                timerScript.congelar();
                timercongeladoScript.congelar();

                foreach (InimigoDireita moscadireita in andardireitascript)
                {
                    moscadireita.inimigoAndarDireita();
                }
                foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
                {
                    moscaesquerda.inimigoAndarDireita();
                }

                pontos.aumentarPontos();
                ganharmoedas();
                Instantiate(particula, new Vector2(-2f, -0.25f), Quaternion.identity);
                Destroy(hit.collider.gameObject);

                timerScript.tempoatual += adicionarTempo;
                timercongeladoScript.tempoatual += adicionarTempo;

                animator.ResetTrigger("Atacando");
                animator.SetTrigger("Atacando");

                //scoreScript.ResetTrigger("reset");
                scoreScript.SetTrigger("reset");

                scoreScript.ResetTrigger("hit");
                scoreScript.SetTrigger("hit");

                timercongeladoscript.ResetTrigger("congelar");
                timercongeladoscript.SetTrigger("congelar");

                spawnerscript.spawnar();
            }

        }



    }

    public void LoadScore()
    {
        DadosJogo scorezin = SaveSystem.LoadScore();

        Score.highscore = scorezin.highscoreatual;
    }

    public void SaveScore()
    {
            SaveSystem.SaveScore(pontos);
    }

    void ganharmoedas()
    {
        


        randomNumMoedasChance = Random.Range(1, variavelChanceMoedas);

        if(randomNumMoedasChance == 2)
        {



            CoinVariable.moedas += 1;
            Instantiate(moedasaindo,new Vector2(0f, 1f), Quaternion.identity);
            int randomNumMoedinha = Random.Range(1, 3);
            if (randomNumMoedinha == 1)
            {
                audiomanager.Play("moeda1");
            }
            else
            {
                audiomanager.Play("moeda2");
            }

        }

    }

    void arrumarbug()
    {
        if(dIdentifier.temnadireita == true && eIdentifier.temnaesquerda == true)
        {
            int rngbug = Random.Range(1, 3);
            if(rngbug == 1)
            {
                Destroy(dIdentifier.pitchuco);
            }
            if(rngbug == 2)
            {
                Destroy(eIdentifier.pitchuco2);
            }
        }

        cooldownress -= 1f * Time.deltaTime;

        if(cooldownress <= 0)
        {
            resscabo = true;
        }
        if(cooldownress > 0)
        {
            resscabo = false;
        }

    }

    void baterRaiva()
    {
        if (raivaligado == true && dIdentifier.temnadireita == true)
        {

            pontos.aumentarPontos();
            ganharmoedas();
            Instantiate(particula, dIdentifier.pitchuco.transform.position, Quaternion.identity);
            Destroy(dIdentifier.pitchuco);

            timerScript.tempoatual += adicionarTempo;
            timercongeladoScript.tempoatual += adicionarTempo;
            animator.ResetTrigger("RaivaComendo");
            animator.SetTrigger("RaivaComendo");

            //scoreScript.ResetTrigger("reset");
            scoreScript.SetTrigger("reset");

            scoreScript.ResetTrigger("hit");
            scoreScript.SetTrigger("hit");

            spawnerscript.spawnar();



        }

        if (raivaligado == true && eIdentifier.temnaesquerda == true)
        {


            pontos.aumentarPontos();
            ganharmoedas();
            Instantiate(particula, eIdentifier.pitchuco2.transform.position, Quaternion.identity);
            Destroy(eIdentifier.pitchuco2);

            timerScript.tempoatual += adicionarTempo;
            timercongeladoScript.tempoatual += adicionarTempo;
            animator.ResetTrigger("RaivaComendo");
            animator.SetTrigger("RaivaComendo");

            //scoreScript.ResetTrigger("reset");
            scoreScript.SetTrigger("reset");

            scoreScript.ResetTrigger("hit");
            scoreScript.SetTrigger("hit");

            spawnerscript.spawnar();

        }


        foreach (InimigoDireita moscadireita in andardireitascript)
        {
            moscadireita.inimigoAndarDireita();
        }
        foreach (InimigoEsquerda moscaesquerda in andaresquerdascript)
        {
            moscaesquerda.inimigoAndarDireita();
        }

    }


    public void deixaraivaon()
    {
        raivaligado = true;
    }

    void perderJogoPorTempo()
    {
        if (timerScript.tempoatual <= 0 && Botao.perdido == false)
        {
            perder();
        }
    }

    void adicionandoTempoPorClique()
    {

    }

}
