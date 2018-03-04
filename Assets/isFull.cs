using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFull : MonoBehaviour {
	
	// Use this for initialization
	public GameObject player;
	public bool isfull;
	public GameObject currentPizza;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pickUpPizza()
	{
		player.GetComponent<characterMovement>().currentPickedup = currentPizza;
		currentPizza.transform.SetParent(player.transform);
		currentPizza = null;
		isfull = false;
	}
}
