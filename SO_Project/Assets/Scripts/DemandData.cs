using UnityEngine;

[CreateAssetMenu(fileName = "Demand Data", menuName = "Custom SO/Variables/Demand Data")]
public class DemandData : ScriptableObject
{
    public Item Item;
    public float MinTime;
    public float MaxTime;
}
