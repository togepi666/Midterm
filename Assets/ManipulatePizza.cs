using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatePizza : MonoBehaviour
{

	public bool inOven;

	public bool hasPepperoni;
	public bool hasMushrooms;
	public bool hasOnions;
	public bool hasCheese;
	public bool isCooked;
	public float startingZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (inOven)
		{
			transform.position = Vector3.MoveTowards(transform.position,transform.position - new Vector3(0, 0, 10f),.5f);
			isCooked = true;
			if (transform.position.z < startingZ - 9.5f)
			{
				inOven = false;
			}
		}
	}
	
}
