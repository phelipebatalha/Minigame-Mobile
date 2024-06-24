using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
        {
            currentAmount++;
        }
    }
    
    public void SpellCasted()
    {
        if(goalType == GoalType.Cast)
        {
            currentAmount++;
        }
    }
    public void SpellCasted2()
    {
        if(goalType == GoalType.CastHard)
        {
            currentAmount++;
        }
    }
}
public enum GoalType
{
    Kill,
    Cast,
    CastHard
}