using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Quest quest;
    public void EnemyKill()
    {
        if(quest.isActive)
            {
                quest.goal.EnemyKilled();
                if(quest.goal.IsReached())
                {
                    HUD.Instance.points += 50;
                    quest.Complete();
                }
            }
        HUD.Instance.points += 5;
    }
    public void SpellCast()
    {
        if(quest.isActive)
            {
                quest.goal.SpellCasted();
                if(quest.goal.IsReached())
                {
                    HUD.Instance.points += 30;
                    quest.Complete();
                }
            }
    }
    public void SpellCast2()
    {
        if(quest.isActive)
            {
                quest.goal.SpellCasted2();
                if(quest.goal.IsReached())
                {
                    HUD.Instance.points += 50;
                    quest.Complete();
                }
            }
    }
}
