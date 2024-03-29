using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    private Vector3 initialSize;
    private int totalInitialCards;
    public List<CardBase> initListCards;
    private PlayerController player;


    //Animations Variables
    private GameObject tempCard;
    public float timeToShowPlayer;
    private float currentTimeToShowPlayer;
    private bool moveToHand;
    private Vector3 positionShowPlayer;
    private Vector3 positionHand;
    private Vector3 targetPosition;
    public float dumbGetCard;

    private bool canPlayerControl;



    void Start()
    {
        initialSize = transform.localScale;
        totalInitialCards = initListCards.Count;

        positionHand = player.hand.transform.position;
        positionShowPlayer = player.hand.positionToShowPlayer.position;
        canPlayerControl = player.canPlayerControl;

    }

    void Update()
    {
        if (moveToHand && tempCard != null)
        {
            currentTimeToShowPlayer += Time.deltaTime;
            if (currentTimeToShowPlayer > timeToShowPlayer )
            {
                positionHand = player.hand.positionNextCard;
                targetPosition = positionHand;
            }
            
            tempCard.transform.position = Vector3.Lerp(tempCard.transform.position, targetPosition, dumbGetCard * Time.deltaTime);
            
            if (Vector3.Distance(tempCard.transform.position, positionHand) < 50)
            {
                CardBase tempCardComponent = tempCard.GetComponent<CardBase>();
                tempCardComponent.SetOnHand();
                tempCardComponent.SetStartPosition(positionHand);
                tempCard = null;
            }
        }
    }

    public void GetCard()
    {
        if (initListCards.Count > 0)
        { 
            int randCardIndex = Random.Range(0, initListCards.Count);
            CardBase selectedCard = initListCards [randCardIndex];
            initListCards.RemoveAt(randCardIndex);

            tempCard = Instantiate(selectedCard.gameObject, transform.position, selectedCard.transform.rotation) as GameObject;
            ResizeDeck();
            
            moveToHand = true;
            targetPosition = positionShowPlayer;
            currentTimeToShowPlayer = 0;

            player.hand.AddCards(tempCard.GetComponent<CardBase>(), canPlayerControl);
        }
    }

    private void ResizeDeck()
    {
        Vector3 newSize = transform.localScale;
        newSize.y = initListCards.Count * initialSize.y / totalInitialCards;

        transform.localScale = newSize;

        if (initListCards.Count == 0)
            GetComponent<Renderer>().enabled = false;

    }

    public void SetupDeck (PlayerController playerToSet)
    {
        player = playerToSet;
    }

}
