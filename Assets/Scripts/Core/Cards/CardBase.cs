using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    public string cardTitle;
    public string cardName;
    public string cardLore;

    public TextMeshPro textCardTitle;
    public TextMeshPro textCardName;
    public TextMeshPro textCardLore;


    protected void Start()
    {
        
        textCardTitle.text = cardTitle;
        textCardName.text = cardName;
        textCardLore.text = cardLore;

    }


    protected void Update()
    {
        
    }
}
