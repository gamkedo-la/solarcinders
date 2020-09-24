using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EventManager))]
public class EventManagerInspector : Editor
{
    
    public override void OnInspectorGUI()
    {

        base.DrawDefaultInspector();

        EventManager myEventManager = (EventManager)target;

        if (GUILayout.Button("Sort By Spawn Time"))
        {

            myEventManager.SortByTime();

        }

        if(GUILayout.Button("Delete Bookmarked Event"))
        {

            myEventManager.DeleteEvent();

        }

        if(GUILayout.Button("Timeshift Events from Bookmark Onwards"))
        {

            myEventManager.ShiftEvents();

        }

    }


}
