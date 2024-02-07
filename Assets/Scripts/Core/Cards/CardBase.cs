using System;
using TMPro;
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

    private GameController gameController;

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

        if (Input.GetMouseButtonDown(0)) //ação do click do botão esquerdo do mouse
        {
            RightMouseClick();
        }

    }

    private void RightMouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.transform.gameObject;
            GameController.instance.OpenCardView();

            if (selectedObject == this.gameObject)
            {
                // Verifica de quem é a vez no turno atual
                PlayerController currentPlayer = GameController.instance.GetCurrentPlayer();

                // Move a carta para o local correspondente
                string viewSlotName = currentPlayer == GameController.instance.player1 ? "CardViewP1" : "CardViewP2";
                GameObject cardViewer = GameObject.Find(viewSlotName);
                GameObject tempCardViewer = Instantiate(this.gameObject) as GameObject;
                tempCardViewer.transform.parent = cardViewer.transform;
                tempCardViewer.transform.localPosition = new Vector3(0, 0, 0);
                if (currentPlayer == GameController.instance.player1){
                    tempCardViewer.transform.localRotation = Quaternion.Euler(0, 0, 0);  // Rotação para o jogador 1
                }else{
                    tempCardViewer.transform.localRotation = Quaternion.Euler(0, 180, 0);  // Rotação para o jogador 2
                }
            }
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
