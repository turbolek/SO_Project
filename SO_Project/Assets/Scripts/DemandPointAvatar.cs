using UnityEngine;

public class DemandPointAvatar : MonoBehaviour
{
    [SerializeField]
    private DemandPointData _data;
    [SerializeField]
    private GameEvent _itemDeliveredEvent;
    [SerializeField]
    private DemandBubble _bubble;

    private DemandPoint _demandPoint;
    public DemandPoint DemandPoint => _demandPoint;

    public void Initialize()
    {
        _demandPoint = new DemandPoint(_data.DemandData, _itemDeliveredEvent);

        _demandPoint.DemandStarted += OnDemandStarted;
        _demandPoint.DemandCompleted += OnDemandCompleted;
        _demandPoint.ItemRejected += OnItemRejected;

        _bubble.Hide();
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
        _bubble.Show(_data.DemandData);
        Debug.Log("Demand for item: " + _data.DemandData.Item + " started by: " + _data.Name);
    }

    private void OnDemandCompleted(DemandPoint demandPoint)
    {
        _bubble.Hide();
        Debug.Log("Demand completed: " + _data.Name);
    }

    private void OnItemRejected(DemandPoint demandPoint, Item item)
    {
        Debug.Log("Item: " + item.Name + " rejected by: " + _data.Name);
    }
}
