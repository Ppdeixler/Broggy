using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI hishscoretext;

    void Update()
    {
        hishscoretext.text = Score.highscore.ToString();
    }


}
