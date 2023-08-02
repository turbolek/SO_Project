using UnityEngine;
[CreateAssetMenu(fileName = "Vector3", menuName = "Custom SO/Variables/Vector3")]

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
