using UnityEngine;

public class DemandPointAvatar : MonoBehaviour
{
    [SerializeField]
    private DemandPointData _data;
    public DemandPointData Data => _data;
    [SerializeField]
    private VoidGameEvent _itemDeliveredEvent;
    [SerializeField]
    private DemandPointAvatarGameEvent _avatarSpawnedEvent;
    [SerializeField]
    private DemandPointAvatarGameEvent _demandStartedEvent;
    [SerializeField]
    private DemandPointAvatarGameEvent _demandCompletedEvent;

    private DemandPoint _demandPoint;
    public DemandPoint DemandPoint => _demandPoint;

    private void Awake()
    {
        _avatarSpawnedEvent?.Raise(this);
    }

    public void Initialize()
    {
        _demandPoint = new DemandPoint(_data.DemandData, _itemDeliveredEvent);

        _demandPoint.DemandStarted += OnDemandStarted;
        _demandPoint.DemandCompleted += OnDemandCompleted;
        _demandPoint.ItemRejected += OnItemRejected;
    }

    private void OnDestroy()
    {
        _demandPoint.DemandStarted -= OnDemandStarted;
        _demandPoint.DemandCompleted -= OnDemandCompleted;
        _demandPoint.ItemRejected -= OnItemRejected;
    }

    public void Activate()
    {
        _demandPoint.Activate();
    }

    private void OnDemandStarted(DemandPoint demandPoint)
    {
        _demandStartedEvent?.Raise(this);
        Debug.Log("Demand for item: " + _data.DemandData.Item + " started by: " + _data.Name);
    }

    private void OnDemandCompleted(DemandPoint demandPoint)
    {
        _demandCompletedEvent?.Raise(this);
        Debug.Log("Demand completed: " + _data.Name);
    }

    private void OnItemRejected(DemandPoint demandPoint, Item item)
    {
        Debug.Log("Item: " + item.Name + " rejected by: " + _data.Name);
    }
}
