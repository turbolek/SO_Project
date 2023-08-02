using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DemandPointAvatarCollection", menuName = "Custom SO/Variables/DemandPointAvatarCollection")]

public class DemandPointAvatarCollection : ResetableScriptableObject
{
    public DemandPointAvatarCollection DefaultState;
    public Dictionary<DemandPoint, DemandPointAvatar> Value;

    [SerializeField]
    private VoidGameEvent _changedEvent;

    public override void ResetMe()
    {
        Value = DefaultState.Value;
    }

    public void Add(DemandPoint demandPoint, DemandPointAvatar avatar)
    {
        if (Value == null)
        {
            Value = new Dictionary<DemandPoint, DemandPointAvatar>();
        }

        if (!Value.ContainsKey(demandPoint))
        {
            Value.Add(demandPoint, avatar);
        }
        else
        {
            Value[demandPoint] = avatar;
        }

        _changedEvent?.Raise();
    }

    public void Remove(DemandPoint demandPoint)
    {
        if (Value.ContainsKey(demandPoint))
        {
            Value.Remove(demandPoint);
        }
        _changedEvent?.Raise();
    }
}
