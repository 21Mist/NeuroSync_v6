using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public PlayerController player1;
    public PlayerController player2;

    public int currentTurn = 1;

    public bool isPlayerOneStarting;


    void Start()
    {
        instance = this;
        int rand = Random.Range(1, 100);
        isPlayerOneStarting = rand > 50;
    }

    void Update()
    {
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
