using UnityEngine;
using UnityEngine.UI;

public class AttackButtonScript : MonoBehaviour
{
    public Button attackButton;  // O botão de ataque
    public PlayerController player;  // O jogador

    public GameController gameController;  // O gerenciador do jogo


    void Start()
    {
        // Desative o botão de ataque no início
        attackButton.interactable = false;
    }

    void Update()
    {
        // Verifique se uma arma está em campo
        PlayerController currentPlayer = gameController.GetCurrentPlayer();  // Use o método GetCurrentPlayer() para buscar o player atual
        string fieldSlotName = currentPlayer == gameController.player1 ? "FieldWeaponSlot" : "FieldWeaponSlot2";
        GameObject weaponSlot = GameObject.Find(fieldSlotName);
        if (weaponSlot.transform.childCount > 0)
        {
            // Se uma arma estiver em campo, ative o botão de ataque
            attackButton.interactable = true;
        }
        else
        {
            // Se não houver arma em campo, desative o botão de ataque
            attackButton.interactable = false;
        }
    }


    public void OnAttackButtonClicked()
    {
        // Quando o botão de ataque é clicado, faça o jogador atacar
        PlayerController currentPlayer = gameController.GetCurrentPlayer();
        PlayerController opponentPlayer = currentPlayer == gameController.player1 ? gameController.player2 : gameController.player1;

        // Aplique o dano ao herói adversário
        HeroCard opponentHero = opponentPlayer.GetComponentInChildren<HeroCard>();
        if (opponentHero != null)
        {
            currentPlayer.Attack(opponentHero);
        }
    }
}
