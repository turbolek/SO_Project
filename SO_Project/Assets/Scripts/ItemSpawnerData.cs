using UnityEngine;

[CreateAssetMenu(fileName = "Item Spawner Data", menuName = "Custom SO/Variables/Item Spawner Data")]
public class ItemSpawnerData : ScriptableObject
{
    public string Name;
    public ItemSpawnData SpawnData;
}
