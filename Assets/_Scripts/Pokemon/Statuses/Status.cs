using System.Collections;

[System.Serializable]
public class Status
{
    public virtual IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }
}

