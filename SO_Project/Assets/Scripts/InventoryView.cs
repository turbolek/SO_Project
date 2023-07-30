using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private InventoryItemView _itemViewPrefab;

    private List<InventoryItemView> _itemViews = new List<InventoryItemView>();

    private void OnEnable()
    {
        PopulateInventory();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    private void PopulateInventory()
    {
        ClearInventory();
        foreach (Item item in _inventory.Items)
        {
            InventoryItemView itemView = Instantiate(_itemViewPrefab, transform);
            itemView.DisplayItem(item);
            _itemViews.Add(itemView);
        }
    }

    private void ClearInventory()
    {
        //TODO use object pool to avoid garbage creation
        for (int i = _itemViews.Count - 1; i >= 0; i--)
        {
            Destroy(_itemViews[i].gameObject);
        }

        _itemViews.Clear();
    }
}
