using UnityEngine;
using UnityEngine.UI;

public class DemandBubble : MonoBehaviour
{
    [SerializeField]
    private Image _demandImage;

    public void Show(DemandData data)
    {
        _demandImage.sprite = data.Item.Sprite;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
