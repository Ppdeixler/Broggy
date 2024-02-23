using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DescricaoAnim : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public Button botaozin;
    //[SerializeField] private GameObject clickedButton;
    [SerializeField] private GameObject descricao;
    private RectTransform imagemthis;
    private Vector3 scaleAtual;
    [SerializeField] private float velocidadesubir;
    private bool buttonIsPressed;

    void Start()
    {
        imagemthis = descricao.GetComponent<RectTransform>();
    }

    void Update()
    {
        scaleAtual = imagemthis.localScale;
        limite();
        aumentaediminui();
    }

    public void aumentaediminui()
    {

        if (buttonIsPressed == true && scaleAtual.x < 1.45f )
        {
            imagemthis.localScale = new Vector3(scaleAtual.x += velocidadesubir * Time.deltaTime, scaleAtual.y += velocidadesubir * Time.deltaTime, scaleAtual.z += velocidadesubir * Time.deltaTime);
        }

        if(buttonIsPressed == false && scaleAtual.x > 0f)
        {
            imagemthis.localScale = new Vector3(scaleAtual.x -= velocidadesubir * Time.deltaTime, scaleAtual.y -= velocidadesubir * Time.deltaTime, scaleAtual.z -= velocidadesubir * Time.deltaTime);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonIsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsPressed = false;
    }

    void limite()
    {
        if(imagemthis.localScale.x <= 0f)
        {
            imagemthis.localScale = new Vector3(0f, 0f, 0f);
        }
        if (imagemthis.localScale.x >= 1.5f)
        {
            imagemthis.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    

}
