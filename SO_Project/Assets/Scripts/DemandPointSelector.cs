using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandPointSelector : MonoBehaviour
{
    [SerializeField]
    private DemandPointValue _selectedDemandPoint;
    [SerializeField]
    private ItemValue _selectedItem;
    [SerializeField]
    private VoidGameEvent _demandPointSelectedEvent;
    [SerializeField]
    private CameraValue _gameplayCamera;
    [SerializeField]
    private Vector3Value _mousePosition;

    private Ray _ray;

    public void SelectDemandPoint()
    {
        _selectedDemandPoint.Value = GetDemandPoint();
        _demandPointSelectedEvent?.Raise();
    }

    private DemandPoint GetDemandPoint()
    {
        DemandPoint demandPoint = null;

        _ray = _gameplayCamera.Value.ScreenPointToRay(_mousePosition.Value);

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            DemandPointAvatar avatar = hitInfo.transform.GetComponentInParent<DemandPointAvatar>();
            if (avatar != null)
            {
                demandPoint = avatar.DemandPoint;
            }
        }

        return demandPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_ray.origin, _ray.direction * 1000);
    }
}
