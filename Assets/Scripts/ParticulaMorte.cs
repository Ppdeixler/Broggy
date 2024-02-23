using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaMorte : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
