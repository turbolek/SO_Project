using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField]
    private ItemValue _selectedItem;

    public void DropItem(DemandPointAvatar avatar)
    {
        if (_selectedItem.Value != null && avatar != null)
        {
            avatar.DemandPoint.DeliverItem(_selectedItem.Value);
        }
    }
}
