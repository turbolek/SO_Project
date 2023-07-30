using UnityEngine;

[CreateAssetMenu]
public class IntValue : ResetableScriptableObject
{
    public readonly IntValue DefaultState;
    public int Value;

    public override void ResetMe()
    {
        if (DefaultState != null)
        {
            Value = DefaultState.Value;
        }
    }
}
