using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatePizza : MonoBehaviour
{

	public bool inOven;

	public bool hasPepperoni;
	public bool hasMushrooms;
	public bool hasOnions;
	public bool hasCheese;
	public bool isCooked;
	public int pepperoniCount;
	public int mushroomCount;
	public int cheeseCount;
	public float startingZ;
	public bool currentlyInOven;

	public GameObject waitingTable;
	// Use this for initialization
	void Start ()
	{
		waitingTable = GameObject.Find("Cube");
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		if (inOven)
		{
			if (waitingTable.GetComponent<isFull>().isfull == false || transform.position.z > startingZ - 17)
			{
				transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 0, 10f), .04f);
				isCooked = true;
			}
			
		if (transform.position.z < startingZ - 22.5f)
			{
				inOven = false;
				waitingTable.GetComponent<isFull>().isfull = true;
				waitingTable.GetComponent<isFull>().currentPizza = gameObject;
			}
			
		}
	}
	
}
