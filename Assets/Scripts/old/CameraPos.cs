using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {

	public GameObject target;
	public GameObject gun;
	public GameObject dummy;

	public float length = 0;

	public Vector3 up = new Vector3 (0, 0, 0);
	public Vector3 boom = new Vector3(0,0,0);
	public Vector3 arm = new Vector3(0,0,0);
	public Vector3 T = new Vector3 (0, 0, 0);
	public Vector3 G = new Vector3 (0, 0, 0);

	public Vector3 perp = new Vector3(0,0,0);

	public Vector3 a = new Vector3(0,0,0);
	public Vector3 b = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		boom = target.transform.forward * -5f;
		boom += up;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			moveRight ();
		} else {
			zeroX();
		}

		T = target.transform.position;

		G = gun.transform.position;

		a = target.transform.position - gun.transform.position;
		b = target.transform.position - dummy.transform.position;

		perp = Vector3.Cross (a, b);

		arm = perp * length;




		gameObject.transform.position = target.transform.position + boom + arm;
	
	}

	void moveLeft()
	{

		if (length < 1.2) 
		{
			length += (Time.deltaTime * 2);
		} 


	}

	void moveRight()
	{



		if (length > -1.2) 
		{
			length -= (Time.deltaTime * 2);
		} 

	}

	void zeroX()
	{

		if (length > 0) {
			length -= (Time.deltaTime * 3);
		}
		if (length < 0) {

			length += (Time.deltaTime * 3);
		}

	}


}
