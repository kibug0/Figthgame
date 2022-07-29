using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(comboSystem1))]
 public class TestWriter : Editor
 {
     comboSystem1 myScrip;
    string filePath = "Assets/Scripts/";
    string fileName = "ActionEnum";
 
    private void OnEnable()
    {
        myScrip = (comboSystem1)target;
    }
 
    public override void OnInspectorGUI()
    {
         base.OnInspectorGUI();
         
         filePath = EditorGUILayout.TextField("Path", filePath);
         fileName = EditorGUILayout.TextField("Name", fileName);
         //if(GUI.Button(new Rect (5, 100, 100, 25),"Save"))
         if(GUILayout.Button("Save"))
         {
            /*
            List<string> names = new List<string>();
            for(int i = 0; i < myScrip.Attacks.Count; i++)
            {
                names.Add(myScrip.Attacks[i].name);
                
            }
            */

            EditorMethod.WriteToEnum(filePath, fileName, myScrip.ActionTypes);

            
         }
    }
 }
