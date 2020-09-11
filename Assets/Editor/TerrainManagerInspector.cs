using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TerrainManager))]
public class TerrainManagerInspector : Editor
{


    public override void OnInspectorGUI()
    {



        base.DrawDefaultInspector();

        TerrainManager myTerrainManager = (TerrainManager)target;

        if (GUILayout.Button("Preview Terrain"))
        {
            myTerrainManager.PreviewTerrain();
        }
        if (GUILayout.Button("Clear"))
        {
            myTerrainManager.Clear();
        }


    }




        // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
