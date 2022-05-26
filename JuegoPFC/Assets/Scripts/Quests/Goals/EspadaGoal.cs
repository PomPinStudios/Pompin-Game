using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaGoal : Quest.QuestGoal
{
    public string Object;

    public override string GetDescription()
    {
        return $"Busca la {Object}";
    }

    public override void Initialize()
    {
        base.Initialize();
        EventManager.Instance.AddListener<ObjectsGameEvent>(OnBuilding);
    }

    private void OnBuilding(ObjectsGameEvent eventInfo)
    {
        if (eventInfo.EventDescription == Object)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
