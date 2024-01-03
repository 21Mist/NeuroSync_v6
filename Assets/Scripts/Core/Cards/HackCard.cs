using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HackCard : CardBase
{
    public string hackEffect;

    public TextMeshPro texthackEffect;

    void Start()
    {
        base.Start();
        texthackEffect.text = hackEffect;
    }

    void Update()
    {
        base.Update();
    }
}