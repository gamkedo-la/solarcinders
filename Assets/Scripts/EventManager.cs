using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventManager : MonoBehaviour
{

  

    public Event[] events;

    int i = 0;

    float countUp = 0;

    public int Bookmark;

    public int Shift;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        countUp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countUp += Time.deltaTime;

        if (events[i].spawnTime >= countUp)
        {
            
            Instantiate(events[i].E, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                     
            i++;
        }
    }

    public void ShiftEvents()
    {

        for(int j = Bookmark; j < events.Length; j++)
        {
            events[j].spawnTime += Shift;

        }

    }


    public void SortByTime()
    {


    }

}

[System.Serializable]
public struct Event
{
    public GameObject E;

    public int spawnTime;

}
