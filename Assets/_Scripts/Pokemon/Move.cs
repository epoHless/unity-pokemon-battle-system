[System.Serializable]
public class Move
{
    public MoveSO moveSO;
    public int currentPP;

    public void ExecuteMove(Pokemon owner)
    {
        if (currentPP <= 0) return;
        
        currentPP--;
        moveSO.ExecuteMove(owner);
    }

    public void SetPP()
    {
        currentPP = moveSO.PP;
    }
}