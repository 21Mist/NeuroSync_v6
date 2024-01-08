using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HeroCard
{

    public DeckController deck;
    public HandPlayerBehaviour hand;

    public bool canPlayerControl;

    void Start()
    {
        base.Start();
        deck.SetupDeck(this);
        hand.SetPlayer(this);
    }

    void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.P))
            deck.GetCard();
    }

    public override void OnDamage()
    {
    }

    public override void OnDie()
    {
    }

}
