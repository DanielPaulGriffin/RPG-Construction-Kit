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

    public void AddJournalEntry()
    {

    }
}

public class JournalEntry
{
    public List<Entry> entries;
    public string id;
}

public class Entry
{
   public string entryText;
   public int index;
   public List<string> conditions;
}
