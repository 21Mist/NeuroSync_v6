using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    public string cardTitle;
    public string cardName;
    public string cardLore;

    public TextMeshPro textCardTitle;
    public TextMeshPro textCardName;
    public TextMeshPro textCardLore;

    public float dumbDragMovimentation;

    private Camera mainCamera;
    private Vector3 startPosition;
    private Vector3 positionToGo;

    private bool onHand;

    protected void Start()
    {
        
        textCardTitle.text = cardTitle;
        textCardName.text = cardName;
        textCardLore.text = cardLore;

        mainCamera = Camera.main;

        startPosition = transform.position;
        positionToGo = startPosition;

    }


    protected void Update()
    {
        if (transform.position != positionToGo)
        {
            transform.position = Vector3.Lerp(transform.position, positionToGo, Time.deltaTime*dumbDragMovimentation);
        }
    }

    public void OnClick()
    {
        
    }

    public void OnMouseOver()
    {
        
    }

    public void OnMouseExit()
    {
        
    }

    public void OnDrag()
    {
            positionToGo = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            positionToGo.y = startPosition.y;
    }

    public void OnDrop()
    {
            positionToGo = startPosition;
            ToggleLayer();
    }
    
    public void OnStartDrag()
    {
            ToggleLayer();
    }

    public void SetOnHand()
    {
        
    }


    public void ToggleLayer()
    {
        int newLayer;

        if (gameObject.layer == LayerMask.NameToLayer("UI"))
            newLayer = LayerMask.NameToLayer("Default");
        else
            newLayer = LayerMask.NameToLayer("UI");

        Transform[] transformsCard = GetComponentsInChildren<Transform>();

        foreach (Transform t in transformsCard)
        {
            t.gameObject.layer = newLayer;
        }

    }

}
