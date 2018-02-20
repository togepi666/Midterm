using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaCreation : MonoBehaviour
{

	public GameObject pizza;

	public GameObject phases;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{

	}
	
	public void CreatePlainPizza()
	{
		Instantiate(pizza, new Vector3(26.5f,4.5f,18f),Quaternion.identity);
		gameObject.SetActive(false);
		phases.GetComponent<PhaseChanger>().inMode = false;
		Cursor.lockState = CursorLockMode.Locked;
		phases.GetComponent<PhaseChanger>().player.GetComponent<characterMovement>().enabled = true;
		
	}
}
