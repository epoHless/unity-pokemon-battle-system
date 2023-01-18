using System.Collections;

[System.Serializable]
public class Move
{
    public MoveSO moveSO;
    public int currentPP;

    public IEnumerator ExecuteMove(Pokemon owner)
    {
        if (currentPP <= 0) yield break;
        
        currentPP--;
        yield return moveSO.ExecuteMove(owner);
    }

    public void SetPP()
    {
        currentPP = moveSO.PP;
    }
}