using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazmorraGoal : Quest.QuestGoal
{
    public string Object;

    public override string GetDescription()
    {
        return $"Encuentra la {Object}";
    }

    public override void Initialize()
    {
        base.Initialize();
        EventManager.Instance.AddListener<PlacesGameEvent>(OnFind);
    }

    private void OnFind(PlacesGameEvent eventInfo)
    {
        if (eventInfo.EventDescription == Object)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}

