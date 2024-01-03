using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{

    public GameObject gameMenu;

    void Start()
    {
        HideMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameMenu.activeSelf)
                HideMenu();
            else
                ShowMenu();
        }
    }

    public void ShowMenu()
    {
        gameMenu.SetActive(true);
    }

    public void HideMenu()
    {
        gameMenu.SetActive(false);
    }
}
