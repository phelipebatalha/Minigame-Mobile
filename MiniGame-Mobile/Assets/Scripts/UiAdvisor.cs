using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAdvisor : MonoBehaviour
{
    [SerializeField] private bool isContainer;
    private void Awake()
    {
        if (isContainer)
        {
            HighscoreTable.ScoresRanking.SetContainer(gameObject.transform);
        }
        else
        {
            HighscoreTable.ScoresRanking.SetTemplate(gameObject.transform);
        }
    }
}
