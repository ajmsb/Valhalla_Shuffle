using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]

    // Cards Class
    public class Cards
    {
        public int Id;
        public GameObject CardPiece;

        // Constructor
        public Cards(int id, GameObject obj)
        {
            Id = id;
            CardPiece = obj;
        }
    }
    // Create list of crads
    public List<Cards> allCards = new List<Cards>();

    // Generating the grid
    public GameObject CardPrefab;
    public Vector2 Grid;
    public void InitCards()
    {
        for (int x = 0; x < Grid.x; x++)
        {
            for (int y = 0; y < Grid.y; y++)
            {
                GameObject NewCard = Instantiate(CardPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
                allCards.Add(new Cards(x + y, NewCard));
            }
        }
    }
    void Start()
    {
        InitCards();
    }

    void Update()
    {
    }


}
