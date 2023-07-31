using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemRemover : MonoBehaviour
{
    [SerializeField]
    private ItemValue _selectedItem;
    [SerializeField]
    private Inventory _inventory;

    public void RemoveSelectedItem()
    {
        if (_selectedItem != null)
        {
            _inventory?.RemoveItem(_selectedItem.Value);
            _selectedItem.Value = null;
        }
    }
}
