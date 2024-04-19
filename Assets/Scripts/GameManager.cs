using System.Collections.Generic;
using Unity.VisualScripting;
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

	public List<Card> SelectedCards = new List<Card>();


	// Generating the grid
	public GameObject CardPrefab;
	public Vector2 Grid;
	public Card LastClickedCard;

	// Function to Initialize Cards
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
	// Function for Checking Double Ids
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

	public Card GetCard(GameObject HitInfoCollider)
	{
		for (int i = 0; i < Cards.Count; i++)
		{
			if (HitInfoCollider == Cards[i].CardUnit)
			{
				return Cards[i];
			}
		}
		return null;
	}
	void Start()
	{
		InitCard();
	}
	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D ClickInfo;
			ClickInfo = Physics2D.Raycast(
				Camera.main.ScreenToWorldPoint(
					new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), Vector3.zero, Mathf.Infinity);

			if (ClickInfo.collider == null)
			{
				Debug.Log("No object clicked.");
			}
			else
			{
				if (ClickInfo.transform.CompareTag("Card"))
				{
					LastClickedCard = GetCard(ClickInfo.transform.gameObject);
					if (SelectedCards.Contains(LastClickedCard) == false)
					{
						SelectedCards.Add(LastClickedCard);
						LastClickedCard.CardUnit.transform.rotation = Quaternion.Euler(0, 0, 0);
					}
					if (SelectedCards.Count == 2)
					{
						if (SelectedCards[0].Id == SelectedCards[1].Id)
						{
							Destroy(SelectedCards[0].CardUnit);
							Destroy(SelectedCards[1].CardUnit);
							SelectedCards.Clear();
						}
						else
						{
							SelectedCards[0].CardUnit.transform.rotation = Quaternion.Euler(0, 180, 0);
							SelectedCards[1].CardUnit.transform.rotation = Quaternion.Euler(0, 180, 0);
							SelectedCards.Clear();
						}
					}
				}
			}
		}
	}

}
