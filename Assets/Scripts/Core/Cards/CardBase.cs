using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    public string cardType;
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

    }


    protected void Update()
    {
        if (transform.position != positionToGo && onHand)
        {
            transform.position = Vector3.Lerp(transform.position, positionToGo, Time.deltaTime * dumbDragMovimentation);
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
        if (onHand)
        {
            positionToGo = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            positionToGo.y = startPosition.y;
        }
    }

    public void OnDrop()
    {
        if (onHand)
        {
            positionToGo = startPosition;
            ToggleLayer();
        }
    }

    public void OnStartDrag()
    {
        if (onHand)
        {
            ToggleLayer();
        }
    }

    public void SetOnHand()
    {
        onHand = true;
    }

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position;
        positionToGo = startPosition; 
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
