using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaCreation : MonoBehaviour
{

	public GameObject pizza;

	public GameObject phases;

	public GameObject childButton;

	public GameObject pepperonis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{

	}
	
	public void CreatePlainPizza()
	{
		GameObject Bizza = Instantiate(pizza, new Vector3(39.5f,4.85f,18f),Quaternion.identity);
		childButton.gameObject.SetActive(false);
		phases.GetComponent<PhaseChanger>().inMode = false;
		Cursor.lockState = CursorLockMode.Locked;
		phases.GetComponent<PhaseChanger>().player.GetComponent<characterMovement>().enabled = true;
		
	}

	
}
