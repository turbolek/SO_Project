using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demand Point Data", menuName = "Custom SO/Variables/Demand Point Data")]
public class DemandPointData : ScriptableObject
{
    public string Name;
    public DemandData DemandData;

    public DemandPointGameEvent DemandStartedEvent;
    public DemandPointGameEvent DemandCompletedEvent;
    public ItemGameEvent ItemRejectedEvent;
    public ItemGameEvent ItemDeliveredEvent;
}
