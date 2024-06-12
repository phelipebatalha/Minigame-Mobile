using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{ 
    public GameObject questWindow;
    public GameObject questTable;
    public Quest quest;
    public Text titleText;
    public Text descriptionText;
    public Text pointsText;
    //public Bullet bullet;

    public void closeMissionTable()
    {
        questTable.SetActive(!questTable.activeSelf);
    }
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        pointsText.text = quest.pointsReward.ToString();
    }
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        //bullet.quest = quest;
    }
}
