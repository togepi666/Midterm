using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseChanger : MonoBehaviour {

	public GameObject mainTable;
	public GameObject cuttingTable;
	public GameObject oven;
	public GameObject player;
	public Button pizzaMaker;
	public bool inMode = false;
	// Use this for initialization
	void Start () {

}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(player.transform.position, mainTable.transform.position) < 5)
		{
			
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
		else
		{	
			Cursor.lockState = CursorLockMode.Locked;
			player.GetComponent<characterMovement>().enabled = true;
			pizzaMaker.gameObject.SetActive(false);
			inMode = false;

		}
	}
}
