using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public DeckController deck1;
    public DeckController deck2;
    public static GameController instance;
    public PlayerController player1;
    public PlayerController player2;

    private PlayerController currentPlayer;  // O jogador atual


    public Camera mainCamera;  // A câmera principal
    public Camera uiCamera;  // A câmera UI
    public Transform player1CameraPosition;  // A posição da câmera para o jogador 1
    public Transform player2CameraPosition;  // A posição da câmera para o jogador 2

    public bool cardPlayedTurn; // verifica se foi jogado carta no turno         

    void Start()
    {
        instance = this;
        currentPlayer = player1;
    }

    void Update()
    {
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EndTurn()
    {
        // Mude o turno para o outro jogador
        if (currentPlayer == player1)
        {
            deck1.GetCard();
            currentPlayer = player2;
            // Mova as câmeras para a posição do jogador 2
            mainCamera.transform.position = player2CameraPosition.position;
            uiCamera.transform.position = player2CameraPosition.position;
            mainCamera.transform.rotation = player2CameraPosition.rotation;
            uiCamera.transform.rotation = player2CameraPosition.rotation;

        }
        else
        {
            deck2.GetCard();
            currentPlayer = player1;
            // Mova as câmeras para a posição do jogador 1
            mainCamera.transform.position = player1CameraPosition.position;
            uiCamera.transform.position = player1CameraPosition.position;
            mainCamera.transform.rotation = player1CameraPosition.rotation;
            uiCamera.transform.rotation = player1CameraPosition.rotation;
        }

    }

    public PlayerController GetCurrentPlayer()
    {
        // Retorne o jogador atual
        return currentPlayer;
    }

}
