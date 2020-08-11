using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Greetings))]
public class CustomGreetingsInspector : Editor
{
    string greetingID;
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
        EditorGUILayout.LabelField("Greetings Editor - DPG");
        DrawDefaultInspector();
        Greetings greetings = (Greetings)target;


        greetingID = EditorGUILayout.TextField("Greeting ID:", greetingID);

        if (GUILayout.Button("Create New Entry"))
        {
            GUIUtility.keyboardControl = 0;
            // EditorUtility.SetDirty(this);
            // serializedObject.ApplyModifiedProperties();
            // this.Repaint();
            greetings.AddGreetingEntry(greetingID);

        }
        //  serializedObject.ApplyModifiedProperties();
    }
}
