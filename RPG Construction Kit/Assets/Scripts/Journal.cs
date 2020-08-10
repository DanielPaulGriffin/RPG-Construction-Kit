using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Journal : MonoBehaviour,ICondition<int>
{
    
    public List<JournalEntry> journalEntries;

    public void Start()
    {
        
    }
    public bool CheckCondition(int index)
    {
        return true;
    }

    public void AddJournalEntry(string id)
    {
        if (journalEntries==null)
        {
            journalEntries = new List<JournalEntry>();
        }
        JournalEntry je = new JournalEntry();
       
        je.id = id;
        journalEntries.Add(je);
       // je.entries = new List<Entry>();
    }
}

[System.Serializable]
public class JournalEntry
{
    public string id;
    public List<Entry> entries;
}

[System.Serializable]
public class Entry
{
   public string entryText;
   public int index;
  // public List<string> conditions;
}
