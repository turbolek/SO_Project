using UnityEngine;

[CreateAssetMenu(fileName = "Item Value", menuName = "Custom SO/Variables/Item Value")]
public class ItemValue : ResetableScriptableObject
{
    public readonly ItemValue DefaultState;
    [SerializeField]
    private Item _value;
    public Item Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            ItemChangedEvent?.Raise(value);
        }
    }

    public ItemGameEvent ItemChangedEvent;

    public override void ResetMe()
    {
        if (DefaultState != null)
        {
            Value = DefaultState.Value;
        }
    }
}
