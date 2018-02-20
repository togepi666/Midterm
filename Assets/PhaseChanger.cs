using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseChanger : MonoBehaviour {

	public GameObject mainTable;
	public GameObject cuttingTable;
	public GameObject oven;
	public GameObject pizzaTable;
	public GameObject player;
	public Button pizzaMaker;
	public Button addPepperoni;
	public bool inMode = false;
	public Button TurnOnOven;
	public Text pressSpace;
	// Use this for initialization
	void Start () {

}
	
	// Update is called once per frame
	void Update ()
	{
		pressSpace.gameObject.SetActive(false);
		
		if (Vector3.Distance(player.transform.position, cuttingTable.transform.position) < 5)
		{
			pressSpace.gameObject.SetActive(true);
			
			//pressSpace.gameObject
		}

		if (Vector3.Distance(player.transform.position, oven.transform.position)< 15)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (!inMode && player.GetComponent<characterMovement>().currentPickedup != null)
				{
					Cursor.lockState = CursorLockMode.None;
					player.GetComponent<characterMovement>().enabled = false;
					TurnOnOven.gameObject.SetActive(true);
					inMode = true;
				}
				else
				{
					Cursor.lockState = CursorLockMode.Locked;
					player.GetComponent<characterMovement>().enabled = true;
					TurnOnOven.gameObject.SetActive(false);
					inMode = false;
				}
			}
		}

		if (Vector3.Distance(player.transform.position, pizzaTable.transform.position) < 5)
		{
			pressSpace.gameObject.SetActive(true);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (!inMode && player.GetComponent<characterMovement>().currentPickedup !=null)
				{
					Cursor.lockState = CursorLockMode.None;
					player.GetComponent<characterMovement>().enabled = false;
					addPepperoni.gameObject.SetActive(true);
					inMode = true;
				}
				else
				{
					Cursor.lockState = CursorLockMode.Locked;
					player.GetComponent<characterMovement>().enabled = true;
					addPepperoni.gameObject.SetActive(false);
					inMode = false;
				}
			}
		}
		
		if (Vector3.Distance(player.transform.position, mainTable.transform.position) < 5)
		{
			pressSpace.gameObject.SetActive(true);
			Debug.Log("Press Space");
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (!inMode)
				{
					Cursor.lockState = CursorLockMode.None;
					player.GetComponent<characterMovement>().enabled = false;
					pizzaMaker.gameObject.SetActive(true);
					inMode = true;
				}
				else
				{
					Cursor.lockState = CursorLockMode.Locked;
					player.GetComponent<characterMovement>().enabled = true;
					pizzaMaker.gameObject.SetActive(false);

					inMode = false;
				}
			}
		}
	}
}
