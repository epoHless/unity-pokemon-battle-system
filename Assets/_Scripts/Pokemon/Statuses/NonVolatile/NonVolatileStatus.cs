using System.Collections;

[System.Serializable]
public class NonVolatileStatus : Status
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }
}