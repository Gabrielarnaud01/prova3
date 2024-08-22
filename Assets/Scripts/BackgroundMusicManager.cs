using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance;

    void Awake()
    {
        // Verifica se j� existe uma inst�ncia deste objeto
        if (instance == null)
        {
            // Se n�o existe, esta ser� a inst�ncia ativa e ela n�o ser� destru�da entre cenas
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se j� existe uma inst�ncia, destrua o novo objeto
            Destroy(gameObject);
        }
    }
}
