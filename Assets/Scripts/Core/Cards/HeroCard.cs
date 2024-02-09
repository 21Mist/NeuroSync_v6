using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class HeroCard : LifeBase
{
    public string heroSkill;
    public string heroImplantSlots1, heroImplantSlots2, heroImplantSlots3, heroImplantSlots4;
    public string heroBatterySlotsP, heroBatterySlotsM, heroBatterySlotsG;

    public int batteryCharge = 0;

    public TextMeshPro textHeroSkill;
    public TextMeshPro textHeroImplantSlots1, textHeroImplantSlots2, textHeroImplantSlots3, textHeroImplantSlots4;
    public TextMeshPro textHeroBatterySlotsP, textHeroBatterySlotsM, textHeroBatterySlotsG;

    void Start()
    {
        base.Start();
        textHeroSkill.text = heroSkill;
        textHeroImplantSlots1.text = heroImplantSlots1;
        textHeroImplantSlots2.text = heroImplantSlots2;
        textHeroImplantSlots3.text = heroImplantSlots3;
        textHeroImplantSlots4.text = heroImplantSlots4;
        textHeroBatterySlotsP.text = heroBatterySlotsP;
        textHeroBatterySlotsM.text = heroBatterySlotsM;
        textHeroBatterySlotsG.text = heroBatterySlotsG;


    }

    void Update()
    {
        base.Update();

    }

    public void IncreaseBatteryCharge()
    {
        SoundEffect.Instance.PlaySoundBatteryCharge();
        batteryCharge += 1;
    }

    public override void OnDamage()
    {
    }

    public override void OnDie()
    {
        PlayerController currentPlayer = GameController.instance.GetCurrentPlayer();
        string winner = "Player 2";
        if (currentPlayer == GameController.instance.player1)
        {
            winner = "Player 1";
        }
        PlayerPrefs.SetString("Winner", winner);

        Debug.Log("Fim de jogo.");
        SceneManager.LoadScene("GameOver");
    }

}
