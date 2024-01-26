using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCard : CardBase
{
    public GameController gameController;

    private PlayerController currentPlayer;
    private Button attackButton;  // O botão de ataque

    public string weaponEffect;
    public int weaponDamage;

    public TextMeshPro textWeaponEffect;
    public TextMeshPro textWeaponDamage;

    void Start()
    {
        base.Start();
        textWeaponEffect.text = weaponEffect;
        textWeaponDamage.text = weaponDamage.ToString();

        currentPlayer = gameController.GetCurrentPlayer();

        // Obtenha o botão de ataque
        GameObject attackButtonObject = GameObject.Find("AttackButton");
        if (attackButtonObject != null)
        {
            attackButton = attackButtonObject.GetComponent<Button>();
        }

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

                    // Mova a carta para o campo de arma correspondente
                    string fieldSlotName = currentPlayer == GameController.instance.player1 ? "FieldWeaponSlot" : "FieldWeaponSlot2";
                    GameObject weaponSlot = GameObject.Find(fieldSlotName);
                    GameObject tempCardField = Instantiate(this.gameObject) as GameObject;
                    tempCardField.transform.parent = weaponSlot.transform;
                    tempCardField.transform.localPosition = new Vector3(0, 0, 0);

                    // Ative o botão de ataque
                    GameObject attackButton = GameObject.Find("AttackButton");
                    if (attackButton != null)
                    {
                        attackButton.GetComponent<Button>().interactable = true;
                    }

                    // Remova a carta da mão do jogador
                    Destroy(this.gameObject);
                    GameController.instance.CardPlayed();
                }
            }
        }
    }


}