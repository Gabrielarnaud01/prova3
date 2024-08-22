using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Referência ao Slider
    private AudioSource backgroundMusic;

    void Start()
    {
        // Acessa o BackgroundMusicManager na cena inicial
        backgroundMusic = FindObjectOfType<BackgroundMusicManager>().GetComponent<AudioSource>();

        // Define o valor inicial do slider como o volume atual da música
        volumeSlider.value = backgroundMusic.volume;

        // Adiciona um listener para chamar a função SetVolume quando o valor do slider mudar
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Função para ajustar o volume
    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
