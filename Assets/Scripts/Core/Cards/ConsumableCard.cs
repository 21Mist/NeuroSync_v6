using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsumableCard : CardBase
{

    public string consumableEffect;

    public TextMeshPro textConsumableEffect;

    void Start()
    {
        base.Start();
        textConsumableEffect.text = consumableEffect;
    }

    void Update()
    {
        base.Update();
    }
}
