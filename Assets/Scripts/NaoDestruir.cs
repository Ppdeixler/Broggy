using UnityEngine;
using UnityEngine.SceneManagement;
public class NaoDestruir : MonoBehaviour
{
    private static NaoDestruir instance;

    private void Awake()
    {
        // Verifica se j� existe uma inst�ncia deste objeto
        if (instance == null)
        {
            // Se n�o existir, esta inst�ncia se torna o objeto singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se j� existir outra inst�ncia, destrua esta
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Verifica se a cena atual � a cena "X"
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            // Se for a cena "X", destrua a musica
            Destroy(gameObject);
        }
    }
}
