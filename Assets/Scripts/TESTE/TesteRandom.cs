using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteRandom : MonoBehaviour
{
    private TesteSmooth testesmooth;
    [SerializeField] GameObject testesmoothobject;
    void Start()
    {
        testesmooth = testesmoothobject.GetComponent<TesteSmooth>();
    }

    public void setaonumero()
    {
        testesmooth.target = 1f;
    }


}
