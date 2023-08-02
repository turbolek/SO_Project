using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Custom SO/Variables/Inventory")]

public class Inventory : ResetableScriptableObject
{
    public readonly Inventory DefaultState;

    public IntValue Capacity;
    public List<Item> Items = new List<Item>();
    public VoidGameEvent InventoryChangedEvent;
    public VoidGameEvent InventoryFullEvent;

    public bool HasRoom()
    {
        return Capacity.Value > Items.Count;
    }

    public void AddItem(Item item)
    {
        if (HasRoom())
        {
            Items.Add(item);
            InventoryChangedEvent?.Raise();
        }
        else
        {
            InventoryFullEvent?.Raise();
        }
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
