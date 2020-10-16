using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //if (GetComponent<PlayerManager>() != null && GetComponent<PlayerManager>().rolling == false)
        //{
            if (target != null)
            {
                transform.LookAt(target.transform);
            }
       // }
	
	}
}
