using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

public class ToppingsScript : MonoBehaviour
{
	public GameObject pepperonis;

	public GameObject cheeses;

	public GameObject mushrooms;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void addPepperoni()
	{
		GameObject pickedUp = GetComponent<characterMovement>().currentPickedup;
		GameObject pep= Instantiate(pepperonis, new Vector3(0, 1, 0), Quaternion.identity);
		pep.transform.position = pickedUp.transform.position;
		pep.transform.Translate(new Vector3(0,.24f,0));
		pep.transform.SetParent(pickedUp.transform);
		pickedUp.GetComponent<ManipulatePizza>().hasPepperoni = true;
	}

	public void addCheese()
	{
		GameObject pickedUp = GetComponent<characterMovement>().currentPickedup;
		GameObject cheese = Instantiate(cheeses, new Vector3(0, 1, 0), Quaternion.identity);
		cheese.transform.position = pickedUp.transform.position;
		cheese.transform.Translate(new Vector3(0,.24f,0));
		cheese.transform.SetParent(pickedUp.transform);
		pickedUp.GetComponent<ManipulatePizza>().hasCheese = true;
	}
	public void addMushrooms()
	{
		GameObject pickedUp = GetComponent<characterMovement>().currentPickedup;
		GameObject mushroom = Instantiate(mushrooms, new Vector3(0, 1, 0), Quaternion.identity);
		mushroom.transform.position = pickedUp.transform.position;
		mushroom.transform.Translate(new Vector3(0,.24f,0));
		mushroom.transform.SetParent(pickedUp.transform);
		pickedUp.GetComponent<ManipulatePizza>().hasMushrooms = true;
	}
}
