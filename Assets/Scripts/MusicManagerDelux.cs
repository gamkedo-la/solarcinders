using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerDelux : MonoBehaviour
{

    public AudioSource intro;
    public AudioSource loop;

    // Start is called before the first frame update
    void Start()
    {
        intro.Play();
        loop.loop = true;
        loop.PlayDelayed(intro.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
