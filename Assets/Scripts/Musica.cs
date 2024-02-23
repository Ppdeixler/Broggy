using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private AudioSource musica;
    [SerializeField] private GameObject musicaobjeto;

    void Start()
    {
        musica = GetComponent<AudioSource>();
    }

    void Update()
    {
        musica.volume = AudioManager.volumemusica;
    }
}
