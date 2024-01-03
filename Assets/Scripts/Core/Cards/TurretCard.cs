using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurretCard : LifeBase
{

    public string turretSkill;

    public TextMeshPro textTurretSkill;

    void Start()
    {
        base.Start();
        textTurretSkill.text = turretSkill;

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
