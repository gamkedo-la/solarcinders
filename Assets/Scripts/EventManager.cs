using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventManager : MonoBehaviour
{

    public int DEBUGStartTime = 0;

    public GameObject empty;

    public int Bookmark;

    public int Shift;


    public Event[] events;

    int i = 0;

    float countUp = 0;

    

    
    


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        countUp = 0;

        SortByTime();

        //empty = GameObject.Find("EmptyEvent");

        if (DEBUGStartTime != 0)
        {

            countUp = DEBUGStartTime;

            StartTime();

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (i > events.Length - 1)
        {

            //End the level
            return;

        }


        countUp += Time.deltaTime;

        if (events[i].spawnTime <= countUp)
        {

            GameObject E = Instantiate(events[i].E, gameObject.transform.position, Quaternion.identity, gameObject.transform);

            E.GetComponent<EnemyBase>().SpawnTime = events[i].spawnTime;

            i++;
        }
    }

    public void ShiftEvents()
    {

        for (int j = Bookmark; j < events.Length; j++)
        {
            events[j].spawnTime += Shift;

        }

    }


    public void SortByTime()
    {

        Event temp;

        for (int p = 0; p < events.Length; p++)
        {
            for (int sort = 0; sort < events.Length - 1; sort++)
            {
                if (events[sort].spawnTime > events[sort + 1].spawnTime)
                {
                    temp = events[sort + 1];
                    events[sort + 1] = events[sort];
                    events[sort] = temp;
                }
            }
        }
    }

    public void DeleteEvent()
    {


        for (int a = Bookmark; a < events.Length -1; a++)
        {

            events[a] = events[a + 1];

        }

        events[events.Length -1].E = empty;
        events[events.Length-1].spawnTime = events[events.Length - 2].spawnTime + 1;


    }

    void StartTime()
    {

        foreach(Event EV in events)
        {

            if(EV.spawnTime < countUp)
            {

                i++;

            }

        }



    }
}

[System.Serializable]
public struct Event
{
    public GameObject E;

    public int spawnTime;

}
