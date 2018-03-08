using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.UIElements;
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

	public float timeLeft;

	public Text timeRemanining;

	public Text ending;

	public GameObject panel;
	public GameObject startingPanel;
	public bool startGame = false;
	// Use this for initialization
	void Start ()
	{
		timeLeft = 150;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!startGame)
		{
			Time.timeScale = 0;
			player.GetComponent<characterMovement>().enabled = false;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Time.timeScale = 1;
				startGame = true;
				startingPanel.gameObject.active = false;
				player.GetComponent<characterMovement>().enabled = true;
			}
		}
		if (timeLeft <= 0)
		{
			gameEnd();
			player.GetComponent<characterMovement>().enabled = false;
			Time.timeScale = 0;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale = 1;
				player.GetComponent<characterMovement>().enabled = true;
			}

		}
		else
		{
			timeRemanining.text = timeLeft.ToString("F2");
			timeLeft -= Time.deltaTime;
			pressSpace.gameObject.SetActive(false);


			if (Vector3.Distance(player.transform.position, pizzaTable.transform.position) < 5)
			{
				pressSpace.gameObject.SetActive(true);
				if (Input.GetKeyDown(KeyCode.Space))
				{
					if (player.GetComponent<characterMovement>().currentPickedup == null)
					{
						pizzaTable.GetComponent<PizzaCreation>().CreatePlainPizza(player.gameObject);
					}
				}
			}

			if (Vector3.Distance(player.transform.position, oven.transform.position) < 4)
			{
				if (player.GetComponent<characterMovement>().currentPickedup != null)
				{
					pressSpace.gameObject.SetActive(true);

					if (Input.GetKeyDown(KeyCode.Space))
					{
						Debug.Log("Should be moving");
						player.GetComponent<characterMovement>().currentPickedup.transform.parent = null;
						player.GetComponent<characterMovement>().currentPickedup.GetComponent<ManipulatePizza>().inOven = true;
						player.GetComponent<characterMovement>().currentPickedup = null;
					}
				}
			}

			if (Vector3.Distance(player.transform.position, pepperoniTable.transform.position) < 3)
			{
				if (player.GetComponent<characterMovement>().currentPickedup != null)
				{
					pressSpace.gameObject.SetActive(true);

					if (Input.GetKeyDown(KeyCode.Space))
					{
						toppingsHandler.GetComponent<ToppingsScript>().addPepperoni();
					}
				}
			}

			if (Vector3.Distance(player.transform.position, mushroomTable.transform.position) < 3)
			{
				if (player.GetComponent<characterMovement>().currentPickedup != null)
				{				pressSpace.gameObject.SetActive(true);

					if (Input.GetKeyDown(KeyCode.Space))
					{
						toppingsHandler.GetComponent<ToppingsScript>().addMushrooms();
					}
				}
			}

			if (Vector3.Distance(player.transform.position, cheeseTable.transform.position) < 3)
			{
				if (player.GetComponent<characterMovement>().currentPickedup != null)
				{
					pressSpace.gameObject.SetActive(true);

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
					pressSpace.gameObject.SetActive(true);

					if (Input.GetKeyDown(KeyCode.Space))
					{
						waitingTable.GetComponent<isFull>().pickUpPizza();
						player.GetComponent<characterMovement>().pickingUp = false;
					}
				}
			}
		}
	}

	public void gameEnd()
	{
		panel.gameObject.SetActive(true);
		if (player.GetComponent<characterMovement>().points > 50)
		{
			ending.text = "Congratulations, You will not be fired today.\n" +
			              "Press Space to restart.";
			
		}
		else
		{
			ending.text = "You did so bad, you're fired.\n" +
			              "Press Space to restart.";
		}
		
	}
	
}
