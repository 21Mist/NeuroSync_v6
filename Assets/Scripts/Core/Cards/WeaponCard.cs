using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponCard : CardBase
{
    public string weaponEffect;
    public string weaponDamage;

    public TextMeshPro textWeaponEffect;
    public TextMeshPro textWeaponDamage;

    void Start()
    {
        base.Start();
        textWeaponEffect.text = weaponEffect;
        textWeaponDamage.text = weaponDamage;
    }

    void Update()
    {
        base.Update();
    }
}