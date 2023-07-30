using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TMP_Text _label;

    public void DisplayItem(Item item)
    {
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
}
