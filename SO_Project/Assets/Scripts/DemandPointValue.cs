using UnityEngine;

[CreateAssetMenu(fileName = "Demand Point", menuName = "Custom SO/Variables/Demand Point")]
public class DemandPointValue : ResetableScriptableObject
{
    public DemandPoint Value;

    public override void ResetMe()
    {
    }
}