using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulinhasUhu : MonoBehaviour
{



    [SerializeField] private GameObject player;

    [SerializeField] private Vector2 novaposicao;

    [SerializeField] private float velocidadeX;
    [SerializeField] private float velocidadeY;

    private float inputHorizontal;
    private float inputVertical;

    void Start()
    {
        



    }


    void Update()
    {

        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");


        novaposicao = new Vector2(velocidadeX * inputHorizontal, velocidadeY * inputVertical);

        transform.position = new Vector2(transform.position.x + velocidadeX * Time.deltaTime , transform.position.y + velocidadeY * Time.deltaTime);



    }
        





}


