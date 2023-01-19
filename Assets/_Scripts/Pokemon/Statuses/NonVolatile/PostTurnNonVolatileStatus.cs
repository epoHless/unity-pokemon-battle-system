using System.Collections;

[System.Serializable]
public class PostTurnNonVolatileStatus : NonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }
}