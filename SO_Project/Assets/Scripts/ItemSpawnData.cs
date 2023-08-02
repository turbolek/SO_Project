using UnityEngine;
[CreateAssetMenu(fileName = "Item Spawn Data", menuName = "Custom SO/Variables/Item Spawn Data")]
public class ItemSpawnData : ScriptableObject
{
    public Item Item;

    [Tooltip("Items produced per second")]
    [Min(0f)]
    public float SpawnRate;
}