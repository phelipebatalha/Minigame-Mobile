using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{ 
    public GameObject questWindow;
    public GameObject questTable;
    public Quest quest1;
    public Quest quest2;
    public Quest quest3;
    public Quest quest4;
    public Button acceptButton1;
    public Button acceptButton2;
    public Button acceptButton3;
    public Button acceptButton4;
    public Text titleText;
    public Text descriptionText;
    public Text pointsText;
    public Player Player;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    public void CloseMissionTable()
    {
        questTable.SetActive(!questTable.activeSelf);
        questWindow.SetActive(false);
    }
    
    public void OpenQuestWindow(Quest quest, Button accept)
    {
        accept.gameObject.SetActive(true);
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        pointsText.text = quest.pointsReward.ToString();
    }
    
    public void AcceptQuest(Quest quest)
    {
        questWindow.SetActive(false);
        questTable.SetActive(false);
        quest.isActive = true;
        Player.quest = quest;
    }
    
    public void OpenQuestWindow1()
    {
        OpenQuestWindow(quest1, acceptButton1);
    }
    
    public void OpenQuestWindow2()
    {
        OpenQuestWindow(quest2, acceptButton2);
    }
    
    public void OpenQuestWindow3()
    {
        OpenQuestWindow(quest3, acceptButton3);
    }
    public void OpenQuestWindow4()
    {
        OpenQuestWindow(quest4, acceptButton4);
    }
    
    public void AcceptQuest1()
    {
        AcceptQuest(quest1);
        acceptButton1.gameObject.SetActive(false);
    }
    
    public void AcceptQuest2()
    {
        AcceptQuest(quest2);
        acceptButton2.gameObject.SetActive(false);
    }
    
    public void AcceptQuest3()
    {
        AcceptQuest(quest3);
        acceptButton3.gameObject.SetActive(false);
    }
    public void AcceptQuest4()
    {
        AcceptQuest(quest4);
        acceptButton4.gameObject.SetActive(false);
    }
}
