using UnityEngine;

[CreateAssetMenu(fileName = "Statistic_", menuName = "Pokemon/Statistic/Permanent", order = 0)]
public class PermanentStatistic : ScriptableObject
{
    [field: SerializeField] public float PS { get; private set; }
    [field: SerializeField] public float ATK { get; private set; }
    [field: SerializeField] public float SPATK { get; private set; }
    [field: SerializeField] public float DEF { get; private set; }
    [field: SerializeField] public float SPDEF { get; private set; }
    [field: SerializeField] public float SPD { get; private set; }
}