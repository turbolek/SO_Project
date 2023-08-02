using UnityEngine;
[CreateAssetMenu]
public class Vector3Value : ResetableScriptableObject
{
    public readonly Vector3Value DefaultState;
    public Vector3 Value;

    public override void ResetMe()
    {
        if (DefaultState != null)
        {
            Value = DefaultState.Value;
        }
    }
}
