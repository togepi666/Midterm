using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaCreation : MonoBehaviour
{

	public GameObject pizza;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	public void CreatePlainPizza( GameObject y)
	{
		Debug.Log("CREATED PIZZA");
		GameObject Bizza = Instantiate(pizza, new Vector3(0,0,0),Quaternion.identity);
		Bizza.transform.position = y.transform.position;
		Bizza.transform.Translate(0,1.5f,3f);
		y.GetComponent<characterMovement>().currentPickedup = Bizza;
		Bizza.transform.SetParent(y.transform);
		y.GetComponent<characterMovement>().currentPickedup.GetComponent<Rigidbody>().isKinematic = true;

	}

	
}
