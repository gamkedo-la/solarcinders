using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float timer;
    public float speed;
    public GameObject target = null;
    float step;

	// Use this for initialization
	void Start () {

        if (GameObject.Find("coneMaster").GetComponent<TargetLock>().target != null)
        {
            target = GameObject.Find("coneMaster").GetComponent<TargetLock>().target;
        }

        GameObject.Find("Ship").GetComponent<PlayerManager>().Shots++;

        //Destroy(gameObject, timer);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);
        }
        else
        {
            Vector3 temp = gameObject.transform.position;
            temp += gameObject.transform.forward * speed * Time.deltaTime;
            gameObject.transform.position = temp;
        }
        if(transform.position.z > 800)
        {
            Destroy(gameObject);

        }
	
	}

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "enemy")
        {
            // Debug.Log("hit");
            //GameObject.Find("Ship").GetComponent<PowerUp>().Add(collide.gameObject.GetComponent<Charge>().charge);
            GameObject.Find("Ship").GetComponent<PlayerManager>().Hits++;
            Destroy(gameObject);
        }
    }

	
}
