using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Laser1prefab;
    public GameObject PowerLaserPrefab;
    public Transform gun;
    GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("SceneManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject laser = (GameObject)Instantiate(
                        Laser1prefab,
                        gun.position,
                        gun.rotation, GameManager.transform);

    }

    public void PowerShot()
    {
        GameObject powerLaser = (GameObject)Instantiate(
                        PowerLaserPrefab,
                        gun.position,
                        gun.rotation, GameManager.transform);

    }
}
