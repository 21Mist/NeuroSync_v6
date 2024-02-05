using UnityEngine;
using UnityEngine.UI;

public class EndTurnButtonScript : MonoBehaviour
{
    public Button endTurnButton;  // O botão para terminar o turno
    public GameController gameController;  // O gerenciador do jogo

    public void OnEndTurnButtonClicked()
    {
        // Quando o botão para terminar o turno é clicado, termine o turno
        gameController.EndTurn();
    }
}
