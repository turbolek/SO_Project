using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private InventoryItemView _itemViewPrefab;

    private List<InventoryItemView> _itemViews = new List<InventoryItemView>();
    private ObjectPool<InventoryItemView> _itemViewsPool;

    private void Awake()
    {
        _itemViewsPool = new ObjectPool<InventoryItemView>(_itemViewPrefab, transform, _inventory.Capacity.Value);
    }

    private void OnEnable()
    {
        DisplayInventory();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    public void DisplayInventory()
    {
        ClearInventory();
        foreach (Item item in _inventory.Items)
        {
            InventoryItemView itemView = _itemViewsPool.GetFromPool(true);
            itemView.transform.SetAsLastSibling();
            itemView.DisplayItem(item);
            _itemViews.Add(itemView);
        }
    }

    private void ClearInventory()
    {
        for (int i = 0; i < _itemViews.Count; i++)
        {
            _itemViewsPool.ReturnToPool(_itemViews[i]);
        }

        _itemViews.Clear();
    }


    [SerializeField]
    private Item _itemToAdd;

    [Button]
    public void AddItem()
    {
        _inventory.AddItem(_itemToAdd);
    }

    [Button]
    public void RemoveItem()
    {
        _inventory.RemoveItem(_itemToAdd);
    }

    public void SignalFullState()
    {
        Debug.Log("Inventory full! Item not added.");
    }
}
