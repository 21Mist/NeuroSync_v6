using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupressorCard : CardBase
{

    public string supressorEffect;

    public TextMeshPro textSupressorEffect;

    void Start()
    {
        base.Start();
        textSupressorEffect.text = supressorEffect;
    }

    void Update()
    {
        base.Update();
    }
}
