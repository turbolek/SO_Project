using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    public void RemoveItem(Item item)
    {
        _inventory.RemoveItem(item);
    }
}
