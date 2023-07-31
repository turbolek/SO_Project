using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    [SerializeField]
    private ItemValue _selectedItemValue;
    [SerializeField]
    private GameEvent _itemSelectedEvent;

    public void SelectItem(Item item)
    {
        _selectedItemValue.Value = item;
        _itemSelectedEvent?.Raise();
    }
}
