using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlayerBehaviour : MonoBehaviour
{

    private PlayerController player;
    public Transform positionToShowPlayer;

    public Vector3 rangeCardPosition;
    private Vector3 minPosition;
    private Vector3 maxPosition;

    public int maxCardInHand = 7;
    
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
        
        for (int i = 1; i < cards.Count; i++)
        {
            position = CalcDistanceHandPosition(i, cards.Count+1);
            if (i - 1 < cards.Count)
            {
                cards[i-1].transform.position = position;
            }
        }

        positionNextCard = CalcDistanceHandPosition(cards.Count, cards.Count+1);

    }

    private Vector3 CalcDistanceHandPosition(int indice, int limit)
    {
        float distance = indice/(float) (limit);



        return Vector3.Lerp(minPosition, maxPosition, distance);

    }

    public void AddCards(CardBase card)
    {
            cards.Add(card);
            ReorganizeCards();
    }


}
