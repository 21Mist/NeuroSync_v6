using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public PlayerController player1;

    public int currentTurn = 1;


    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
