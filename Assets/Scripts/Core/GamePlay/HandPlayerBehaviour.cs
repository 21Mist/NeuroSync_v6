using System.Collections.Generic;
using UnityEngine;

public class HandPlayerBehaviour : MonoBehaviour
{

    public BatteryCard FieldCardPrefab;

    private PlayerController player;
    public Transform positionToShowPlayer;

    public Vector3 rangeCardPosition;
    private Vector3 minPosition;
    private Vector3 maxPosition;

    public int maxCardInHand = 10;
    
    private List<CardBase> cards = new List<CardBase>();

    [System.NonSerialized]
    public Vector3 positionNextCard;

    void Start()
    {
        minPosition = transform.position - rangeCardPosition;
        maxPosition = transform.position + rangeCardPosition;
    }


    void Update()
    {

    }

    public void SetPlayer(PlayerController playerToSet)
    {
        player = playerToSet;
    }

    public void ReorganizeCards()
    {
        Vector3 position = transform.position;

        for (int i = 0; i < cards.Count; i++)
        {
            position = CalcDistanceHandPosition(i, cards.Count);
            if (i < cards.Count)
            {
                cards[i].SetStartPosition(position);
            }
        }
        positionNextCard = CalcDistanceHandPosition(cards.Count, cards.Count);
    }

    private Vector3 CalcDistanceHandPosition(int indice, int limit)
    {
        float distance = indice/(float)(limit);

        return Vector3.Lerp(minPosition, maxPosition, distance);

    }

    public void AddCards(CardBase card)
    {
        //if (cards.Count < maxCardInHand)
        //{
            cards.Add(card);
            card.SetStartPosition(positionNextCard);
            ReorganizeCards();
        //}
        //else
        //{
        //    Destroy(card.gameObject, 1);
        //}
    }



}
