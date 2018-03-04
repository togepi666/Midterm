using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PhaseChanger : MonoBehaviour {

	public GameObject oven;
	public GameObject pizzaTable;
	public GameObject player;
	public Text pressSpace;
	public GameObject toppingsHandler;
	
	public GameObject pepperoniTable;

	public GameObject mushroomTable;

	public GameObject cheeseTable;

	public GameObject waitingTable;
	public GameObject[] tables = new GameObject[8];
	// Use this for initialization
	void Start () {

}
	
	// Update is called once per frame
	void Update ()
	{
		pressSpace.gameObject.SetActive(false);	

		if (Vector3.Distance(player.transform.position, pizzaTable.transform.position) < 5)
		{
			pressSpace.gameObject.SetActive(true);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if ( player.GetComponent<characterMovement>().currentPickedup == null)
				{
					pizzaTable.GetComponent<PizzaCreation>().CreatePlainPizza(player.gameObject);
				}
			}
		}

		if (Vector3.Distance(player.transform.position, oven.transform.position) < 15)
		{
			if (player.GetComponent<characterMovement>().currentPickedup != null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Debug.Log("Should be moving");
					player.GetComponent<characterMovement>().currentPickedup.transform.parent = null;
					player.GetComponent<characterMovement>().currentPickedup.GetComponent<ManipulatePizza>().inOven = true;
					player.GetComponent<characterMovement>().currentPickedup = null;
				}
			}
		}
		if (Vector3.Distance(player.transform.position, pepperoniTable.transform.position) < 5)
		{
			if (player.GetComponent<characterMovement>().currentPickedup != null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					toppingsHandler.GetComponent<ToppingsScript>().addPepperoni();
				}
			}
		}
		if (Vector3.Distance(player.transform.position, mushroomTable.transform.position) < 5)
		{
			if (player.GetComponent<characterMovement>().currentPickedup != null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					toppingsHandler.GetComponent<ToppingsScript>().addMushrooms();
				}
			}
		}
		if (Vector3.Distance(player.transform.position, cheeseTable.transform.position) < 5)
		{
			if (player.GetComponent<characterMovement>().currentPickedup != null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					toppingsHandler.GetComponent<ToppingsScript>().addCheese();
				}
			}
		}

		if (Vector3.Distance(player.transform.position, waitingTable.transform.position) < 5)
		{
			if (player.GetComponent<characterMovement>().currentPickedup == null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					waitingTable.GetComponent<isFull>().pickUpPizza();
					player.GetComponent<characterMovement>().pickingUp = false;
				}
			}
		}
		
	}
}
