using UnityEngine;

[CreateAssetMenu(fileName = "Integer", menuName = "Custom SO/Variables/Integer")]

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
