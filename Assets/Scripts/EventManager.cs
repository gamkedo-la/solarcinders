using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventManager : MonoBehaviour
{

    public float DEBUGStartTime = 0;

    public GameObject empty;

    public int Bookmark;

    public int Shift;


    public Event[] events;

    int i = 0;

    int j = 0;

    float countUp = 0;

    GameObject EnemyList;

    
    


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        countUp = 0;


        EnemyList = GameObject.Find("EnemyList");
        Import();

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
        Spawn();

        
    }

    void Spawn()
    {

        if (i > events.Length - 1)
        {

            return;

        }
        if (events[i].spawnTime <= countUp)
        {



            events[i].E.transform.position = events[i].spawnPos;

            events[i].E.GetComponent<EnemyBase>().SpawnTime = events[i].spawnTime;

            events[i].E.GetComponent<EnemyBase>().Active = true;

            i++;

            Spawn();
        }


    }

    public void ShiftEvents()
    {

        for (int k = Bookmark; k < events.Length; k++)
        {
            events[k].spawnTime += Shift;

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

    void Import()
    {

        events = new Event[EnemyList.transform.childCount];

        foreach(GameObject EM in EnemyList.transform)
        {

            events[j].E = EM;

            events[j].spawnTime = EM.transform.position.z - 10000;

            events[j].spawnPos = EM.transform.position;
            events[j].spawnPos.z -= 10000;
            events[j].spawnPos.z -= events[j].spawnTime;

            j++;

        }


    }



}

[System.Serializable]
public struct Event
{
    public GameObject E;

    public float spawnTime;

    public Vector3 spawnPos;

}
