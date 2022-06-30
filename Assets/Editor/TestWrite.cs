using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ComboSystem))]
 public class TestWriter : Editor
 {
     ComboSystem myScrip;
     string filePath = "Assets/Scripts/";
     string fileName = "TestMyEnum";
 
    private void OnEnable()
    {
        myScrip = (ComboSystem)target;
    }
 
    public override void OnInspectorGUI()
    {
         base.OnInspectorGUI();
         
         filePath = EditorGUILayout.TextField("Path", filePath);
         fileName = EditorGUILayout.TextField("Name", fileName);
         if(GUILayout.Button("Save"))
         {
            /*
            List<string> names = new List<string>();
            for(int i = 0; i < myScrip.Attacks.Count; i++)
            {
                names.Add(myScrip.Attacks[i].name);
                
            }*/
            EditorMethod.WriteToEnum(filePath, fileName, myScrip.AttackTypes);

            
         }
    }
 }
