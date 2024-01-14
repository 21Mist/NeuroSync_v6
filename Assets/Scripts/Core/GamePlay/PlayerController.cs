using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HeroCard
{

    public DeckController deck;
    public HandPlayerBehaviour hand;

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

}
