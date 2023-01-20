using System.Collections;

public class PostTurnVolatileStatus : VolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        return base.Execute(manager, pokemon);
    }

    public override IEnumerator OnRemove(StatusManager manager, Pokemon pokemon)
    {
        return base.OnRemove(manager, pokemon);
    }
}