using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpscap : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 80;
    }
}
