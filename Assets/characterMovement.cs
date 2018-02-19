using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class characterMovement : MonoBehaviour
{

// Use this for initialization
	public static Vector3 dir;
	public float speed = 3f;
	public float rotateSpeed = 5;
	public GameObject cam;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Cursor.SetCursor(null,new Vector3(0,0,0),CursorMode.Auto);
		Cursor.lockState = CursorLockMode.Locked;
		Vector3 v3 = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		v3 = transform.TransformDirection(v3);
		//transform.Translate(speed * v3.normalized * Time.deltaTime,Space.Self);  
		//GetComponent<Rigidbody>().AddForce(v3.normalized);
		GetComponent<CharacterController>().Move(v3.normalized * speed * Time.deltaTime);
		//GetComponent<CharacterController>().SimpleMove(v3.normalized * speed * Time.deltaTime);
		
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		float vertical = Input.GetAxis("Mouse Y")* rotateSpeed ;
		transform.Rotate(0, horizontal, 0);
		cam.transform.Rotate(-vertical,0,0);
		//GetComponent<CharacterController>().Move(v3.normalized * speed * Time.deltaTime);

	}
}
