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
    private Camera _camera;

    private Ray _ray;

    private void Update()
    {
        if (_selectedItem.Value != null)
        {
            /* TODO use Unity Input system for event based logic instead of Update
             * Input system variables and events could also be handled by SOs to avoid rigid references 
             */
            if (Input.GetMouseButtonUp(0))
            {
                _selectedDemandPoint.Value = GetDemandPoint();
                _demandPointSelectedEvent?.Raise();
            }
        }
    }

    private DemandPoint GetDemandPoint()
    {
        DemandPoint demandPoint = null;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);

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
