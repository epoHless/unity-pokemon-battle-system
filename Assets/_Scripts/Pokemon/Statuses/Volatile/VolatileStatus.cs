using System.Collections;

[System.Serializable]
public class VolatileStatus : Status
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }
}