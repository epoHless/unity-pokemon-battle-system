using UnityEngine;

[CreateAssetMenu(fileName = "Statistic_", menuName = "Statistic/Permanent", order = 0)]
public class PermanentStatistic : ScriptableObject
{
    [field: SerializeField] public int PS { get; private set; }
    [field: SerializeField] public int ATK { get; private set; }
    [field: SerializeField] public int SPATK { get; private set; }
    [field: SerializeField] public int DEF { get; private set; }
    [field: SerializeField] public int SPDEF { get; private set; }
    [field: SerializeField] public int SPD { get; private set; }
}
