using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class Orders : MonoBehaviour {

	// Use this for initialization
	public GameObject order;
	public int x = 1900;
	public int orderNumber = 0;
	public AudioSource printingNoise;
	public GameObject customer;
	public GameObject[] tables = new GameObject[8];
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 500)
		{
			if (orderNumber < 8)
			{
				newOrder();
				x = 0;
			}
		}
		x++;
	}

	public void newOrder()
	{
		
		printingNoise.Play();
		GameObject correspondingCustomer = Instantiate(customer, tables[orderNumber].transform.position + Vector3.forward*2, Quaternion.identity);
		GameObject theOrder = Instantiate(order, transform.position + new Vector3(0,.2f,0), Quaternion.identity);
		String directions = "# " + orderNumber+1 +"\n";
		theOrder.GetComponent<orderProperties>().location = tables[orderNumber].transform.position;
		
		for (int i = 0; i < 3; i++)
		{
			int x = UnityEngine.Random.Range(0, 4);
			switch (x)
			{
				case 1:
					directions = directions.Insert(directions.Length, "Pepperoni \n");
					theOrder.GetComponent<orderProperties>().reqPepperoni = true;
					theOrder.GetComponent<orderProperties>().pepCount++;
					break;
				case 2:
					directions = directions.Insert(directions.Length, "Cheese \n");
					theOrder.GetComponent<orderProperties>().reqCheese = true;
					theOrder.GetComponent<orderProperties>().cheCount++;

					break;
				case 3:
					directions = directions.Insert(directions.Length, "Mushrooms \n");
					theOrder.GetComponent<orderProperties>().reqMushrooms = true;
					theOrder.GetComponent<orderProperties>().mushCount++;

					break;
			}
		}
		orderNumber++;
		theOrder.transform.GetChild(0).GetComponent<TextMesh>().text = directions;
	}

}
