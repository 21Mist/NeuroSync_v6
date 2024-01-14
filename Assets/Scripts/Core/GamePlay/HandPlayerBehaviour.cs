using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameObject tempCardField = Instantiate(FieldCardPrefab.gameObject) as GameObject;
            tempCardField.transform.parent = GameObject.Find("FieldBatterySlot").transform;
            tempCardField.transform.localPosition = new Vector3(0, 0, 0);
            BatteryCard selectedCard = cards[0].GetComponent<BatteryCard>();
            tempCardField.GetComponent<BatteryCard>();
        }
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
                cards[i-1].SetStartPosition(position);
            }
        }
        positionNextCard = CalcDistanceHandPosition(cards.Count, cards.Count+1);

    }

    private Vector3 CalcDistanceHandPosition(int indice, int limit)
    {
        float distance = indice/(float)(limit);

        return Vector3.Lerp(minPosition, maxPosition, distance);

    }

    public void AddCards(CardBase card)
    {
        if(cards.Count < maxCardInHand)
        {
            cards.Add(card);
            ReorganizeCards();
        }
        else
        {
            Destroy(card.gameObject, 1);
        }
    }


}
