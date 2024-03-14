using TMPro;
using UnityEngine;

public class PlayerController : HeroCard
{
    public GameController gameController;
    public DeckController deck;
    public HandPlayerBehaviour hand;

    public TextMeshProUGUI lifeText;  // O texto da vida do jogador
    public TextMeshPro batteryText; // O texto da bateria do jogador

    // Box mostrador de dano
    public GameObject boxDamage;
    [SerializeField]
    private TextMeshProUGUI txtDamage;
    private int damageDone;


    void Start()
    {
        base.Start();
        deck.SetupDeck(this);
        hand.SetPlayer(this);

        for (int i = 0; i < 5; i++)
        {
            float delay = i * .3f;
        Invoke("BuyInitialCards", delay);
        }

        boxDamage.SetActive(false);

    }


    void Update()
    {
        base.Update();

        UpdateLifeText();
        UpdateBatteryText();


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

    void UpdateBatteryText()
    {
        batteryText.text = "Cargas de Bateria: " + batteryCharge;
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
            int damage = 4;  // Dano fixo
            damageDone = damage;

            // Se houver pelo menos duas cargas de bateria, dobre o dano
            if (batteryCharge >= 2)
            {
                batteryCharge -= 2;
                damage = 15;  // Dano carregado
                damageDone = damage;
            }

            // Aplique o dano ao herói adversário
            if (opponentHero != null)
            {
                opponentHero.ApplyDamage(damage);
            }
            BoxDamageDone();
            gameController.EndTurn();
        }
    }

    public void BoxDamageDone()
    {

        txtDamage.text = (damageDone + " de dano causado");
        boxDamage.SetActive(true);

        Invoke("HideBoxDamage", 2f);
    }

    public void HideBoxDamage()
    {
        boxDamage.SetActive(false);
    }

}
