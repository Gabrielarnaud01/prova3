using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance;

    void Awake()
    {
        // Verifica se já existe uma instância deste objeto
        if (instance == null)
        {
            // Se não existe, esta será a instância ativa e ela não será destruída entre cenas
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se já existe uma instância, destrua o novo objeto
            Destroy(gameObject);
        }
    }
}
