using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCard : CardBase
{
    [SerializeField]
    private GameController gameController;

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.transform.gameObject;

                if (selectedObject == this.gameObject && GameController.instance.CanPlayCard())
                {
                    // Verifique de quem é a vez no turno atual
                    PlayerController currentPlayer = GameController.instance.GetCurrentPlayer();

                    // Mova a carta para o campo de bateria correspondente
                    string fieldSlotName = currentPlayer == GameController.instance.player1 ? "FieldBatterySlot" : "FieldBatterySlot2";
                    GameObject batterySlot = GameObject.Find(fieldSlotName);
                    GameObject tempCardField = Instantiate(this.gameObject) as GameObject;
                    tempCardField.transform.parent = batterySlot.transform;
                    tempCardField.transform.localPosition = new Vector3(0, 0, 0);

                    // Aumente a carga da bateria do jogador correspondente
                    HeroCard hero = currentPlayer.GetComponentInChildren<HeroCard>();
                    if (hero != null)
                    {
                        hero.IncreaseBatteryCharge();
                    }
                    else
                    {
                        Debug.Log("HeroCard component not found in player's children.");
                    }

                    // Remova a carta da mão do jogador
                    Destroy(this.gameObject);
                    GameController.instance.CardPlayed();
                }
            }
        }
    }
}
