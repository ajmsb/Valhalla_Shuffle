using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]

    // Card Class
    public class Card
    {
        public int Id;
        public GameObject CardPiece;

        // Constructor
        public Card(int id, GameObject obj)
        {
            Id = id;
            CardPiece = obj;
        }
    }
    // Create list of crads
    public List<Card> allCards = new List<Card>();

    // Generating the grid
    public GameObject CardPrefab;
    public Vector2 Grid;
    public void InitCard()
    {
        for (int x = 0; x < Grid.x; x++)
        {
            for (int y = 0; y < Grid.y; y++)
            {
                GameObject NewCard = Instantiate(CardPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
                allCards.Add(new Card(x + y, NewCard));
            }
        }
    }
    void Start()
    {
        InitCard();
    }

    void Update()
    {
    }


}
