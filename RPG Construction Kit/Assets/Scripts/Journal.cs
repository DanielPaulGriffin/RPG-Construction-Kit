using B83.LogicExpressionParser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Journal : MonoBehaviour,ICondition<int>
{  
    public List<JournalEntry> journalEntries;
  

   
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
    }

    public void SetAllJournalEntryIndexByID(LogicExpression exp)
    {
        for (int i = 0; i < journalEntries.Count; i++)
        {
            JournalEntry currentEntry = journalEntries[i];
           
                exp[currentEntry.id].Set(currentEntry.index);
        }
        
    }
}

[System.Serializable]
public class JournalEntry
{
    public string id;
    public int index;
    public List<Entry> entries;  
}

[System.Serializable]
public class Entry
{
   public string entryText;
   public int index;
}
