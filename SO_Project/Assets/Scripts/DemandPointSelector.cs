using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandPointSelector : MonoBehaviour
{
    [SerializeField]
    private DemandPointAvatarGameEvent _avatarSelectedEvent;
    [SerializeField]
    private ItemValue _selectedItem;
    [SerializeField]
    private CameraValue _gameplayCamera;
    [SerializeField]
    private Vector3Value _mousePosition;

    private Ray _ray;

    public void SelectDemandPoint()
    {
        _avatarSelectedEvent?.Raise(GetDemandPointAvatar());
    }

    private DemandPointAvatar GetDemandPointAvatar()
    {
        DemandPointAvatar avatar = null;

        _ray = _gameplayCamera.Value.ScreenPointToRay(_mousePosition.Value);

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            avatar = hitInfo.transform.GetComponentInParent<DemandPointAvatar>();
        }

        return avatar;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_ray.origin, _ray.direction * 1000);
    }
}
