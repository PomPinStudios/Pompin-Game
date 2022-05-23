using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject questPrefab;
    [SerializeField] private Transform questsContent;
    [SerializeField] private GameObject questHolder;

    public List<Quest> CurrentQuests;

    private void Awake()
    {
        foreach (var quest in CurrentQuests)
        {
            quest.Initialize();
            quest.QuestCompleted.AddListener(OnQuestCompleted);

            GameObject questObj = Instantiate(questPrefab, questsContent);
            questObj.transform.Find("Icon").GetComponent<Image>().sprite = quest.Information.Icon;

            questObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                questHolder.GetComponent<QuestWindow>().Initialize(quest);
                questHolder.SetActive(true);
            });
        }
    }

    private void OnQuestCompleted(Quest quest)
    {
        questsContent.GetChild(CurrentQuests.IndexOf(quest)).Find("Checkmark").gameObject.SetActive(true);
    }

    public void addQuest(Quest quest)
    {
         CurrentQuests.Add(quest); 
         quest.Initialize();
            quest.QuestCompleted.AddListener(OnQuestCompleted);

            GameObject questObj = Instantiate(questPrefab, questsContent);
            questObj.transform.Find("Icon").GetComponent<Image>().sprite = quest.Information.Icon;

            questObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                questHolder.GetComponent<QuestWindow>().Initialize(quest);
                questHolder.SetActive(true);
            });  
    }
}