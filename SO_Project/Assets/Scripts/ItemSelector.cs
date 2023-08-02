using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    [SerializeField]
    private ItemValue _selectedItemValue;
    [SerializeField]
    private VoidGameEvent _itemSelectedEvent;

    public void SelectItem(Item item)
    {
        Debug.Log("Selecting item: " + item?.Name);
        _selectedItemValue.Value = item;
        _itemSelectedEvent?.Raise();
    }
}
