using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NeurobugCard : CardBase
{
    public string neuroBugEffect;
    public string neuroBugTier1, neuroBugTier2, neuroBugTier3;

    public TextMeshPro textNeuroBugEffect;
    public TextMeshPro textNeuroBugTier1, textNeuroBugTier2, textNeuroBugTier3;

    void Start()
    {
        base.Start();
        textNeuroBugEffect.text = neuroBugEffect;
        textNeuroBugTier1.text = neuroBugTier1;
        textNeuroBugTier2.text = neuroBugTier2;
        textNeuroBugTier3.text = neuroBugTier3;
    }

    void Update()
    {
        base.Update();
    }
}