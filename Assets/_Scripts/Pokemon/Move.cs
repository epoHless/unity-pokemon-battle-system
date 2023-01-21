﻿using System.Collections;

[System.Serializable]
public class Move
{
    public MoveSO moveSO;
    public int currentPP;
    
    public IEnumerator ExecuteMove(Pokemon owner)
    {
        if (currentPP <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{moveSO.Name} has no PP left!",1.5f);
            BattleManager.Instance.ChangeState(new TurnStartBS());
        }

        currentPP--;
        yield return NotificationManager.Instance.ShowNotificationCOR($"{owner.Name} used {moveSO.Name}!",1);
        yield return moveSO.ExecuteMove(owner);
    }

    public void SetPP()
    {
        currentPP = moveSO.PP;
    }
}