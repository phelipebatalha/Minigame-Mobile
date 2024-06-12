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
}
