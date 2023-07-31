using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private ItemSelector _itemSelector;

    private Item _item;
    private bool _selected = false;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    public void DisplayItem(Item item)
    {
        _item = item;

        if (item != null)
        {
            gameObject.SetActive(true);
            _icon.sprite = item.Sprite;
            _label.text = item.Name;
        }
        else
        {
            Hide();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnButtonClicked()
    {
        SetSelected(!_selected);
    }

    private void SetSelected(bool selected)
    {
        _selected = selected;
        Item item = selected ? _item : null;
        _itemSelector.SelectItem(item);
    }
}
