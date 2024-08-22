using UnityEngine;
using TMPro; // Adicione esta linha para usar TextMeshPro

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Alterado para TMP_Text
    private float timeElapsed = 0f; // Tempo decorrido

    void Update()
    {
        // Atualiza o tempo decorrido
        timeElapsed += Time.deltaTime;

        // Converte o tempo em minutos e segundos
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // Atualiza o texto da UI
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
