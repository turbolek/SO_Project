using Sirenix.OdinInspector;
using UnityEngine;

public abstract class ResetableScriptableObject : SerializedScriptableObject, IResetable
{
    public abstract void ResetMe();
}
