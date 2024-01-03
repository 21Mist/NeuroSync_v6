using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroCard : LifeBase
{

    public string heroSkill;
    public string heroImplantSlots1, heroImplantSlots2, heroImplantSlots3, heroImplantSlots4;
    public string heroBatterySlotsP, heroBatterySlotsM, heroBatterySlotsG;

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

    public override void OnDamage()
    {
    }

    public override void OnDie()
    {
    }

}
