using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerCheck : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    void Start()
    {
        // Obtém o vencedor armazenado em PlayerPrefs
        string winner = PlayerPrefs.GetString("Winner", "Unknown");

        // Atualiza o texto para mostrar o vencedor
        winnerText.text = "Vencedor: " + winner;
    }
}
