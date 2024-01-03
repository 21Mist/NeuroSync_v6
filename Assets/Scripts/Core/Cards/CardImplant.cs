using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardImplant : CardBase
{

    public string implantTier1;
    public string implantTier2;
    public string implantTier3;
    public string implantType;

    public TextMeshPro textImplantTier1;
    public TextMeshPro textImplantTier2;
    public TextMeshPro textImplantTier3;
    public TextMeshPro textImplantType;

    void Start()
    {
        base.Start();
        textImplantTier1.text = implantTier1;
        textImplantTier2.text = implantTier2;
        textImplantTier3.text = implantTier3;
        textImplantType.text = implantType;
    }


    void Update()
    {
        base.Update();
    }
}
