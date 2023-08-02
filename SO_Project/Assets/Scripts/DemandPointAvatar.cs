using UnityEngine;

public class DemandPointAvatar : MonoBehaviour
{
    [SerializeField]
    private DemandPointData _data;
    public DemandPointData Data => _data;

    [SerializeField]
    private DemandPointAvatarCollection _avatarCollection;

    [SerializeField]
    private DemandPointAvatarGameEvent _avatarSpawnedEvent;


    private DemandPoint _demandPoint;
    public DemandPoint DemandPoint => _demandPoint;

    private void Start()
    {
        _avatarSpawnedEvent?.Raise(this);
    }

    public void Initialize()
    {
        _demandPoint = new DemandPoint(_data);
        _avatarCollection.Add(_demandPoint, this);
    }

    public void Activate()
    {
        _demandPoint.Activate();
    }
}
