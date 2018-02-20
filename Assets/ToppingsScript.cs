using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

public class ToppingsScript : MonoBehaviour
{
	public GameObject pepperonis;
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
	}
}
