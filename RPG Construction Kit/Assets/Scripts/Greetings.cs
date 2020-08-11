using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.LogicExpressionParser;

public class Greetings : MonoBehaviour, ICondition<int>
{
    public Journal journalScript;//TODO: make the journal script a singleton to avoid these references
    public List<GreetingEntry> greetingEntries;
    public bool CheckCondition(int index)
    {
        return true;
    }

    public void AddGreetingEntry(string id)
    {
        if (greetingEntries == null)
        {
            greetingEntries = new List<GreetingEntry>();
        }
        GreetingEntry greetingEntry = new GreetingEntry();

        greetingEntry.id = id;
        greetingEntries.Add(greetingEntry);
    }

    public void GetRelevantGreeting()
    {
        Parser parser = new Parser();
        for (int i = 0; i < greetingEntries.Count; i++)//for all the greetingSets
        {
            GreetingEntry currentGreetingEntry = greetingEntries[i];
            for (int i2 = 0; i2 < currentGreetingEntry.greetings.Count; i2++)//for each greeting in the greetingSet
            {
                Greeting currentGreeting = currentGreetingEntry.greetings[i2];

                // parse the string expression and create an expression tree for it
                LogicExpression exp = parser.Parse(currentGreeting.conditions[0]);
                SetExpressionVariables(exp);

                if (exp.GetResult())
                {
                    Debug.Log(currentGreeting.greetingText+" is true");
                }
                else
                {
                    Debug.Log(currentGreeting.greetingText + " is false");
                }
            }
        }
    }

    private void SetExpressionVariables(LogicExpression expIn)//loads all our journal data into variables that can be evaluated.
    {
        journalScript.SetAllJournalEntryIndexByID(expIn);  
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GetRelevantGreeting();
        }
    }

}

[System.Serializable]
public class GreetingEntry
{
    public string id;
    public List<Greeting> greetings;
}

[System.Serializable]
public class Greeting
{
    public string greetingText;
    public List<string> conditions;
}


