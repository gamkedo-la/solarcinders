using UnityEngine;
using System.Collections;

public class ShipRotator : MonoBehaviour {

	public float Tpitch = 0;
	public float TpitchR = 0;
	public float Z = 0;

	Quaternion temp = new Quaternion(0,0,0,0);

	public Vector3 a = new Vector3(0,0,0);
	public Vector3 b = new Vector3(0,0,0);
	public Vector3 perp = new Vector3(0,0,0);



	public GameObject fin;
	public GameObject body;
	public Transform gun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		a = fin.transform.position - gun.transform.position;
		b = fin.transform.position - body.transform.position;

		perp = Vector3.Cross (a, b);



	//	if (Input.GetKey (KeyCode.LeftArrow)) {
	//		moveLeft ();
	//	}

	//	else if (Input.GetKey (KeyCode.RightArrow)) {
	//		moveRight ();
	//	}
	//	else 
	//	{

	//		zeroX ();

	//	}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
				moveUp();
			}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			moveDown ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			//gameObject.transform.RotateAround(perp , (-Time.deltaTime* 20));
			moveDown();
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			//gameObject.transform.RotateAround(perp , (Time.deltaTime* 20));
			moveUp();
		}


	}

	void zeroX()
	{

		TpitchR = gameObject.transform.eulerAngles.z;


		//Debug.Log ("zeroing");

		if (gameObject.transform.eulerAngles.z > 330) {
			//gameObject.transform.Rotate (0, 0, Tpitch, Space.Self);
			gameObject.transform.RotateAround(transform.forward ,  Time.deltaTime);
		}

		if (gameObject.transform.eulerAngles.z < 30 && gameObject.transform.eulerAngles.z > .5) {
			gameObject.transform.RotateAround (transform.forward, -1 * Time.deltaTime);
		}

		if (gameObject.transform.eulerAngles.z < .5 || gameObject.transform.eulerAngles.z > 359.5) {
		
			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
		}
	}

	void moveLeft()
	{

		Tpitch = gameObject.transform.eulerAngles.z;

		if (gameObject.transform.eulerAngles.z > 335 || gameObject.transform.eulerAngles.z < 25) {
			gameObject.transform.RotateAround(transform.forward , Time.deltaTime);
		}




	}

	void moveRight()
	{

		Tpitch = gameObject.transform.eulerAngles.z;

		if (gameObject.transform.eulerAngles.z > 335 || gameObject.transform.eulerAngles.z < 25) /*&& gameObject.transform.eulerAngles.z < 1*/ {
			gameObject.transform.RotateAround(transform.forward , -1 * Time.deltaTime);
		}

	
	}

	void moveUp()
	{


		gameObject.transform.RotateAround(perp , (-Time.deltaTime* 20));


	}

	void moveDown ()
	{
		gameObject.transform.RotateAround(perp , (Time.deltaTime* 20));
	}


}
