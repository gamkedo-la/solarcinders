using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLock : MonoBehaviour
{
	public GameObject target;
    public int clip;
    List<GameObject> currentCollisions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject temp = null;
        
        if (target != null && target.transform.position.z < clip)
        {
            target = null;
        }
        if (target == null)
        {
            foreach(GameObject OBJ in currentCollisions)
            {
                if (temp == null)
                {
                    temp = OBJ;
                }
                else if (OBJ.transform.position.z > clip && OBJ.transform.position.z < temp.transform.position.z)
                {
                    temp = OBJ;
                } 
            }

            target = temp;
            //Debug.Log(target.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision");
        if(other.tag == "enemy")
        {
            currentCollisions.Add(other.gameObject);
        }

        if (target != null)
        {
            if(other.transform.position.z > clip && other.transform.position.z < target.transform.position.z)
            {
                target = other.gameObject;
                Debug.Log(target.name);
                return;
            }

        }
        else {
            if (other.transform.position.z > clip)
            {

                if (other.tag == "enemy")
                {
                    target = other.gameObject;
                    Debug.Log(target);
                    return;

                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        currentCollisions.Remove(other.gameObject);

        if (other.gameObject == target)
        {
            target = null;
        }
    }

    void OnTriggerStay(Collider other)
    {
        

    }
}
