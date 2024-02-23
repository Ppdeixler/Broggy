using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class DadosJogo
{

    public int moedasatuais;
    public int highscoreatual;
    public bool[] powerupchancecomprado;
    public bool[] powerupduracaocomprado;
    public bool[] chancedropmoedacomprado;
    public bool[] vidaextracomprado;


    public DadosJogo(Score score)
    {
        highscoreatual = Score.highscore;
    }

    public DadosJogo(CoinVariable coinvariable)
    {
        moedasatuais = CoinVariable.moedas;
    }


    public DadosJogo(Manager manager)
    {
        powerupchancecomprado = new bool[10];
        powerupduracaocomprado = new bool[10];
        chancedropmoedacomprado = new bool[10];
        vidaextracomprado = new bool[5];

        for(int i = 0; i < manager.barraspowerup.Length; i++)
        {
            powerupchancecomprado[i] = manager.barraspowerup[i];
        }
        for (int i = 0; i < manager.barraspowerupduration.Length; i++)
        {
            powerupduracaocomprado[i] = manager.barraspowerupduration[i];
        }
        for (int i = 0; i < manager.barrascoindropchance.Length; i++)
        {
            chancedropmoedacomprado[i] = manager.barrascoindropchance[i];
        }
        for(int i = 0; i < manager.barrasvidaextra.Length; i++)
        {
            vidaextracomprado[i] = manager.barrasvidaextra[i];
        }

    }

}
