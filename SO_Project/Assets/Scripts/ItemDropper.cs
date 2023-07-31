using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField]
    private ItemValue _selectedItem;
    [SerializeField]
    private DemandPointValue _selectedDemandPoint;

    public void DropItem()
    {
        if (_selectedItem.Value != null && _selectedDemandPoint.Value != null)
        {
            _selectedDemandPoint.Value.DeliverItem(_selectedItem.Value);
        }
    }
}
