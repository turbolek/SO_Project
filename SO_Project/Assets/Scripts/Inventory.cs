using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Inventory : ResetableScriptableObject
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

    public override void ResetMe()
    {
        if (DefaultState != null)
        {
            Capacity = DefaultState.Capacity;
            Items = new List<Item>(DefaultState.Items);
        }
    }
}
