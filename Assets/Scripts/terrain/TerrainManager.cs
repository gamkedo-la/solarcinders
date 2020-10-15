using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] Segments;

    public Vector3 SpawnPos = new Vector3(0, 0, 0);

    public int i = 10;

    public int l;

    float timer = 2;

    float reset = 2;

    public float terrainSize = 0;

    public float terrainSpeed = 1;

    List<GameObject> kids = new List<GameObject>();

    float farplane;


    // Start is called before the first frame update
    void Start()
    {
        Clear();

        farplane = GameObject.Find("SceneManager").GetComponent<levelBounds>().z;

        for (int j = 0; j < ((farplane/terrainSize) + 1); j++)
        {

            SpawnPos.z += terrainSize;

            GameObject T = Instantiate(Segments[Random.Range(0, Segments.Length - 1)], SpawnPos, Quaternion.identity, gameObject.transform);
            T.GetComponent<straight>().speed = terrainSpeed;

        }

        i = 10;

        
        timer = terrainSize / terrainSpeed;
        reset = timer;

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.fixedDeltaTime;

        if (timer <0.02)
        {

            GameObject T = Instantiate(Segments[Random.Range(0, Segments.Length - 1)], SpawnPos, Quaternion.identity, gameObject.transform);
            T.GetComponent<straight>().speed = terrainSpeed;

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

            SpawnPos.z += terrainSize;
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
