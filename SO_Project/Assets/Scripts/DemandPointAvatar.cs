using UnityEngine;

public class DemandPointAvatar : MonoBehaviour
{
    [SerializeField]
    private DemandPointData _data;
    private DemandPoint _demandPoint;

    private void Start()
    {
        _demandPoint = new DemandPoint(_data.DemandData);

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
        _demandPoint.StartNewDemand();
    }

    private void OnDemandStarted(DemandPoint demandPoint)
    {
        Debug.Log("Demand for item: " + _data.DemandData.Item + " started by: " + _data.Name);
    }

    private void OnDemandCompleted(DemandPoint demandPoint)
    {
        Debug.Log("Demand completed: " + _data.Name);
    }

    private void OnItemRejected(DemandPoint demandPoint, Item item)
    {
        Debug.Log("Item: " + item.Name + " rejected by: " + _data.Name);
    }
}
