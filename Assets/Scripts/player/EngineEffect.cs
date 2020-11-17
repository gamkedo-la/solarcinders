using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEffect : MonoBehaviour
{


    public float scrollSpeed = 50.0f;
    //spublic string thisTexture;
    public MeshRenderer rend;

    public Vector2 OS;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset(0, new Vector2(offset, offset));
        OS = rend.material.GetTextureOffset(0);
    }
}
