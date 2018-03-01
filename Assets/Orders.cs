using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class Orders : MonoBehaviour {

	// Use this for initialization
	public GameObject order;
	public int x = 1900;
	public bool[] toppings = new bool[5];
	public int orderNumber = 0;
	public AudioSource printingNoise;
	public GameObject customer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 2000)
		{
			newOrder();
			x = 0;
		}
		x++;
	}

	public void newOrder()
	{
		printingNoise.Play();
		orderNumber++;
		
		GameObject theOrder = Instantiate(order, transform.position + new Vector3(0,.2f,0), Quaternion.identity);
		String directions = "# " + orderNumber +"\n";
		
		for (int i = 0; i < 3; i++)
		{
			int x = UnityEngine.Random.Range(0, 4);
			switch (x)
			{
				case 1:
					directions = directions.Insert(directions.Length, "Pepperoni \n");
					theOrder.GetComponent<orderProperties>().reqPepperoni = true;
					break;
				case 2:
					directions = directions.Insert(directions.Length, "Cheese \n");
					theOrder.GetComponent<orderProperties>().reqCheese = true;
					break;
				case 3:
					directions = directions.Insert(directions.Length, "Mushrooms \n");
					theOrder.GetComponent<orderProperties>().reqMushrooms = true;
					break;
			}
		}
		theOrder.transform.GetChild(0).GetComponent<TextMesh>().text = directions;
	}

	
}
