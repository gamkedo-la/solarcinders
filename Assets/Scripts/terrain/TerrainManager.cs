using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] Segments;

    public Vector3 SpawnPos = new Vector3(0, 0, 0);

    public int i = 10;

    public int l;

    public float timer = 2;

    public float reset = 2;

    List<GameObject> kids = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Clear();


        for (int j = 0; j < 11; j++)
        {

            SpawnPos.z += 100;

            Instantiate(Segments[j], SpawnPos, Quaternion.identity, gameObject.transform);
                       
        }

        i = 10;

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.fixedDeltaTime;

        if (timer <=0)
        {

            Instantiate(Segments[i], transform.position, Quaternion.identity, gameObject.transform);

            timer = reset;

            //i++;

        }

    }

    /*public void SpawnTerrain()
    {

        if (i < Segments.Length)
        {
            Instantiate(Segments[i], Segments[i - 1].GetComponent<NextTerrainSpawnPoint>().Next, Quaternion.identity, gameObject.transform);

            i++;
        }
    }*/

    public void PreviewTerrain()
    {
        Clear();

        

        foreach (GameObject chunk in Segments)
        {

            SpawnPos.z += 100;
            Instantiate(chunk, SpawnPos, Quaternion.identity, gameObject.transform);

        }


    }

    public void Clear()
    {
        i = 0;

        SpawnPos.z = -100;

        foreach (Transform child in gameObject.transform)
        {
            kids.Add(child.gameObject);
        }

        if (kids.Count > 0)
        {
            foreach (GameObject child in kids)
            {
                DestroyImmediate(child);
            }
        }

    }


}
