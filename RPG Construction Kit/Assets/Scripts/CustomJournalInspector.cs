using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Journal))]
public class CustomJournalInspector : Editor
{
    string journalID;
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
        EditorGUILayout.LabelField("Journal Editor - DPG");
        DrawDefaultInspector();
        Journal journal = (Journal)target;
        
        
        journalID = EditorGUILayout.TextField("Journal ID:",journalID );
        
        if (GUILayout.Button("Create New Entry"))
        {
            GUIUtility.keyboardControl = 0;
           // EditorUtility.SetDirty(this);
           // serializedObject.ApplyModifiedProperties();
           // this.Repaint();
            journal.AddJournalEntry(journalID);
            
        }
      //  serializedObject.ApplyModifiedProperties();
    }
}
