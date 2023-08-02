using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemView : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Vector3Value _mousePosition;

    private void Start()
    {
        Hide();
    }

    public void DisplayItem(Item item)
    {
        if (item != null)
        {
            Show(item);
        }
        else
        {
            Hide();
        }
    }

    private void Show(Item item)
    {
        _image.enabled = true;
        _image.sprite = item.Sprite;
    }

    private void Hide()
    {
        _image.enabled = false;
    }

    private void Update()
    {
        transform.position = _mousePosition.Value;
    }
}
