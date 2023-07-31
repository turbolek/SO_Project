using UnityEngine;
[CreateAssetMenu]
public class ItemSpawnData : ScriptableObject
{
    public Item Item;

    [Tooltip("Items produced per second")]
    [Min(0f)]
    public float SpawnRate;
}