/*using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ComboSystem))]
public class EditorShowBool : Editor
{
    public override void OnInspectorGUI()
    {
         DrawDefaultInspector(); // for other non-HideInInspector fields
 
         ComboSystem script = (ComboSystem)target;

        for(int i = 0;i<script.Inputproperties.Count;i++)
        {
            script.Inputproperties[i].MOorAT = (movatt)EditorGUILayout.EnumPopup("Start Temp", script.Inputproperties[i].MOorAT );

            if (script.Inputproperties[i].MOorAT == movatt.Attack) // if bool is true, show other fields
            {
                script.Inputproperties[i].Attacktype = (AttackEnum)EditorGUILayout.EnumPopup("Start Temp", script.Inputproperties[i].Attacktype);
             
            }
            else if(script.Inputproperties[i].MOorAT == movatt.Moviment)
            {
                script.Inputproperties[i].direction = (DirectionEnum)EditorGUILayout.EnumPopup("Start Temp", script.Inputproperties[i].direction);
            }
        }
 
         // draw checkbox for the bool
         
         
    }
}
*/
