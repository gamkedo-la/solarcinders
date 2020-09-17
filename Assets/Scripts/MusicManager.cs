using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{

    AudioSource music;


    // Start is called before the first frame update
    void Start()
    {

        music = GetComponent<AudioSource>();
        music.loop = true;
        music.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
