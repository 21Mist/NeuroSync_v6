using UnityEngine;
using UnityEngine.UI;

public class EndTurnButtonScript : MonoBehaviour
{
    public Button endTurnButton;  // O bot�o para terminar o turno
    public GameController gameController;  // O gerenciador do jogo

    public void OnEndTurnButtonClicked()
    {
        // Quando o bot�o para terminar o turno � clicado, termine o turno
        gameController.EndTurn();
    }
}
