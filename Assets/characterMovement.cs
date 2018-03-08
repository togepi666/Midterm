using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class characterMovement : MonoBehaviour
{

// Use this for initialization
	public static Vector3 dir;
	public float speed = 5f;
	public float rotateSpeed = 4;
	public GameObject cam;
	public Boolean pickingUp;
	public GameObject currentPickedup;
	public int points;
	public Text pointDisplay;
	public float completeRot;
	public AudioSource yummy;
	void Start()
	{
		completeRot = 0;
	}

	// Update is called once per frame
	void Update()
	{
		pointDisplay.text = "Pts " + points;

		Debug.Log(currentPickedup);
		Cursor.SetCursor(null, new Vector3(0, 0, 0), CursorMode.Auto);
		Cursor.lockState = CursorLockMode.Locked;
		Vector3 v3 = new Vector3(Input.GetAxisRaw("Horizontal")* 2, 0.0f, Input.GetAxisRaw("Vertical") * 2);
		v3 = transform.TransformDirection(v3 * 10);
		v3 *= speed;
		//transform.Translate(speed * v3.normalized * Time.deltaTime,Space.Self);  
		//GetComponent<Rigidbody>().AddForce(v3.normalized);
		GetComponent<CharacterController>().Move(v3.normalized * Time.deltaTime * 20 );
		//GetComponent<CharacterController>().SimpleMove(v3.normalized * speed * Time.deltaTime);

		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
		//if (Mathf.Sign(vertical) == -1 && transform.rotation.x <= 80)
		//	vertical = 0;
		completeRot += vertical;
		transform.Rotate(0, horizontal, 0);
		completeRot = Mathf.Clamp(completeRot, -80, 80);
		cam.transform.localEulerAngles = new Vector3(-completeRot, 0f,0f);
		//cam.transform.localEulerAngles = new Vector3(Mathf.Clamp(cam.transform.rotation.x, -80, 80), 0,0);
			
		//cam.transform.LookAt(transform.position +transform.forward* 4);
		/*if(cam.transform.rotation.eulerAngles.x < -80)
		{
			cam.transform.rotation = Quaternion.EulerAngles(-80, 0, cam.transform.rotation.z);
		}

		if (cam.transform.rotation.eulerAngles.x > 80)
		{
			cam.transform.rotation = Quaternion.EulerAngles(80,0 , cam.transform.rotation.z);
		}*/


	//GetComponent<CharacterController>().Move(v3.normalized * speed * Time.deltaTime);
		RaycastHit hit;

		

		

		if (Input.GetMouseButtonDown(0))
		{
			if (pickingUp)
			{
				Debug.Log("Detached pizza");
				currentPickedup.transform.SetParent(null);
				currentPickedup.GetComponent<Rigidbody>().isKinematic = false;
				currentPickedup = null;
				pickingUp = false;
			}
			else
			{
				if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit,6))
				{
					if (hit.collider.gameObject.CompareTag("Pizza") )
					{
						Debug.Log("Picked UP");
						currentPickedup = hit.collider.gameObject;
						currentPickedup.GetComponent<Rigidbody>().isKinematic = true;
						hit.collider.gameObject.transform.SetParent(transform);
						pickingUp = true;
					}
				}
			}
		}

		
	}

}
