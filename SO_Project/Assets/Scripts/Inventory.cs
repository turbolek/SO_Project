using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : SerializedScriptableObject, IResetable
{
    public readonly Inventory DefaultState;

    public IntValue Capacity;
    public List<Item> Items = new List<Item>();
    public GameEvent InventoryChangedEvent;

    public void AddItem(Item item)
    {
        Items.Add(item);
        InventoryChangedEvent?.Raise();
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        InventoryChangedEvent?.Raise();
    }

    public void Reset()
    {
        Capacity = DefaultState.Capacity;
        Items = new List<Item>(DefaultState.Items);
    }
}
