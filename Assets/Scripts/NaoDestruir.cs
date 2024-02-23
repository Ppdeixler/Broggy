using UnityEngine;
using UnityEngine.SceneManagement;
public class NaoDestruir : MonoBehaviour
{
    private static NaoDestruir instance;

    private void Awake()
    {
        // Verifica se já existe uma instância deste objeto
        if (instance == null)
        {
            // Se não existir, esta instância se torna o objeto singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se já existir outra instância, destrua esta
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Verifica se a cena atual é a cena "X"
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            // Se for a cena "X", destrua a musica
            Destroy(gameObject);
        }
    }
}
