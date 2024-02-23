using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{

    PlayerController playercontroller;
    public GameObject player;

    public int Pontos;
    public TextMeshProUGUI textScore;
    public static int highscore;

    void Start()
    {
        Pontos = 0;
        playercontroller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        atualizarScore();
        pegarhighscore();
    }

    void pegarhighscore()
    {
        if(highscore < Pontos)
        {
            highscore = Pontos;
        }
    }

    void atualizarScore()
    {
        textScore.text = Pontos.ToString();
        
    }

    public void aumentarPontos()
    {
        Pontos+=1;
    }

}
