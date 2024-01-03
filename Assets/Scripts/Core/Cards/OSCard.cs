using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OSCard : CardBase
{
    public string oSEffect;

    public TextMeshPro textOSEffect;

    void Start()
    {
        base.Start();
        textOSEffect.text = oSEffect;
    }

    void Update()
    {
        base.Update();
    }
}
