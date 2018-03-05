using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderProperties : MonoBehaviour
{

	public int orderNum;

	public Vector3 location;

	public bool reqPepperoni;

	public bool reqCheese;

	public bool reqMushrooms;

	public int pepCount;

	public int mushCount;

	public int cheCount;

	public GameObject player;
	// Use this for initialization
	void Start () {
	player  = GameObject.Find("Player");	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Vector3.Distance(player.transform.position, location) < 5)
		{
			if (player.GetComponent<characterMovement>().currentPickedup != null)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					GameObject setPizza = player.GetComponent<characterMovement>().currentPickedup;
					player.GetComponent<characterMovement>().currentPickedup.transform.parent = null;
					player.GetComponent<characterMovement>().currentPickedup = null;
					setPizza.transform.position = location + Vector3.up / 2;
					
					if (setPizza.GetComponent<ManipulatePizza>().isCooked)
						player.GetComponent<characterMovement>().points += 5;
					
					if (setPizza.GetComponent<ManipulatePizza>().pepperoniCount == pepCount)
						player.GetComponent<characterMovement>().points += (5 * pepCount);

					if (setPizza.GetComponent<ManipulatePizza>().cheeseCount == cheCount)
						player.GetComponent<characterMovement>().points += (5 * cheCount);
					
					if (setPizza.GetComponent<ManipulatePizza>().mushroomCount == mushCount)
						player.GetComponent<characterMovement>().points += (5 * mushCount);

					
				}
			}
		}
	}

}
