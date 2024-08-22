using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Refer�ncia ao Slider
    private AudioSource backgroundMusic;

    void Start()
    {
        // Acessa o BackgroundMusicManager na cena inicial
        backgroundMusic = FindObjectOfType<BackgroundMusicManager>().GetComponent<AudioSource>();

        // Define o valor inicial do slider como o volume atual da m�sica
        volumeSlider.value = backgroundMusic.volume;

        // Adiciona um listener para chamar a fun��o SetVolume quando o valor do slider mudar
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Fun��o para ajustar o volume
    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
