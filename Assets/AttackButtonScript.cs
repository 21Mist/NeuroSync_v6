using UnityEngine;
using UnityEngine.UI;

public class AttackButtonScript : MonoBehaviour
{
    public Button attackButton;  // O bot�o de ataque
    public PlayerController player;  // O jogador

    public GameController gameController;  // O gerenciador do jogo


    void Start()
    {
        // Desative o bot�o de ataque no in�cio
        attackButton.interactable = false;
    }

    void Update()
    {
        // Verifique se uma arma est� em campo
        GameObject weaponSlot = GameObject.Find("FieldWeaponSlot");
        if (weaponSlot.transform.childCount > 0)
        {
            // Se uma arma estiver em campo, ative o bot�o de ataque
            attackButton.interactable = true;
        }
        else
        {
            // Se n�o houver arma em campo, desative o bot�o de ataque
            attackButton.interactable = false;
        }
    }

    public void OnAttackButtonClicked()
    {
        // Quando o bot�o de ataque � clicado, fa�a o jogador atacar
        PlayerController currentPlayer = gameController.GetCurrentPlayer();
        PlayerController opponentPlayer = currentPlayer == gameController.player1 ? gameController.player2 : gameController.player1;

        // Aplique o dano ao her�i advers�rio
        HeroCard opponentHero = opponentPlayer.GetComponentInChildren<HeroCard>();
        if (opponentHero != null)
        {
            currentPlayer.Attack(opponentHero);
        }
    }
}
