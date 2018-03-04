using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingOven : MonoBehaviour
{
	private GameObject pickedUp;

	public GameObject phases;

	public Button childButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void bakePizza()
	{
		pickedUp = GetComponent<characterMovement>().currentPickedup;
		pickedUp.GetComponent<ManipulatePizza>().startingZ = pickedUp.transform.position.z;
		pickedUp.GetComponent<ManipulatePizza>().inOven = true;
		pickedUp.transform.SetParent(null);
		GetComponent<characterMovement>().pickingUp = true;
		Cursor.lockState = CursorLockMode.Locked;
		phases.GetComponent<PhaseChanger>().player.GetComponent<characterMovement>().enabled = true;


	}
}
