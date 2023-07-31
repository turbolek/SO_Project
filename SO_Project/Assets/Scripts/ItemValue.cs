using UnityEngine;

[CreateAssetMenu]
public class ItemValue : ResetableScriptableObject
{
    public readonly ItemValue DefaultState;
    public Item Value;

    public override void ResetMe()
    {
        if (DefaultState != null)
        {
            Value = DefaultState.Value;
        }
    }
}
