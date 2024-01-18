using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : HeroCard
{
    public GameController gameController;
    public DeckController deck;
    public HandPlayerBehaviour hand;

    public TextMeshProUGUI lifeText;  // O texto da vida do jogador

    void Start()
    {
        base.Start();
        deck.SetupDeck(this);
        hand.SetPlayer(this);

        for (int i = 0; i < 7; i++)
        {
            float delay = i * .3f;
        Invoke("BuyInitialCards", delay);
        }
        
        
        
    }


    void Update()
    {
        base.Update();

        UpdateLifeText();


        if (Input.GetKeyDown(KeyCode.P))
            deck.GetCard();
    }

private void BuyInitialCards()
    {
        deck.GetCard();
    }

    public override void OnDamage()
    {
    }

    public override void OnDie()
    {
    }

    void UpdateLifeText()
    {
        if (lifeText != null)
        {
            lifeText.text = GetCurrentLife().ToString();
        }
    }

    public void Attack(HeroCard opponentHero)
    {
        if (gameController.GetCurrentPlayer() == this)
        {
            // Calcule o dano
            int damage = 5;  // Dano fixo

            // Se houver pelo menos duas cargas de bateria, dobre o dano
            if (batteryCharge >= 2)
            {
                batteryCharge -= 2;
                damage = 10;  // Dano dobrado
            }

            // Aplique o dano ao herói adversário
            if (opponentHero != null)
            {
                opponentHero.ApplyDamage(damage);
            }

            gameController.EndTurn();
        }
    }




}
