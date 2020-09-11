using UnityEngine;
using System.Collections;

public class CrosshairPos : MonoBehaviour {

	public GameObject ship;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		gameObject.transform.position = (ship.transform.forward * 39) + ship.transform.position;
		gameObject.transform.rotation = ship.transform.rotation;



	
	}
}
