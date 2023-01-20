using System.Collections.Generic;

[System.Serializable]
public class TurnMove
{
    public Move Move;
    public Pokemon pokemon;

    public TurnMove(Pokemon pokemon, Move move)
    {
        this.pokemon = pokemon;
        this.Move = move;
    }
}

