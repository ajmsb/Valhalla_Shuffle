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
        public GameObject CardUnit;

        // Constructor
        public Card(int id, GameObject obj)
        {
            Id = id;
            CardUnit = obj;
            CardUnit.GetComponent<Renderer>().material.SetTexture("_MainTex", Resources.Load<Texture2D>("Cards/Card_" + Id));
        }
    }

    // Create list of crads
    public List<Card> Cards = new List<Card>();

    // Generating the grid
    public GameObject CardPrefab;
    public Vector2 Grid;

    // Init Cards
    public void InitCard()
    {
        for (int x = 0; x < Grid.x; x++)
        {
            for (int y = 0; y < Grid.y; y++)
            {
                GameObject NewCard = Instantiate(CardPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, -180, 0), transform);

                int id = Random.Range(0, 10);

                while (RepeatingId(id) == true)
                {
                    id = Random.Range(0, 10);
                }
                Cards.Add(new Card(id, NewCard));


            }
        }
    }
    // Checking Double Ids
    public bool RepeatingId(int n)
    {
        int counter = 0;
        for (int i = 0; i < Cards.Count; i++)
        {
            if (n == Cards[i].Id)
            {
                counter++;
            }
        }

        if (counter == 2)
        {
            return true;
        }
        return false;
    }


    void Start()
    {
        InitCard();
    }

    void Update()
    {
    }


}
