using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private ItemSpawnerData _spawnerData;
    [SerializeField]
    private Inventory _targetInventory;

    private bool _isActive;
    public bool IsActive => _isActive;

    private CancellationTokenSource _cancellationTokenSource;

    public void Activate()
    {
        if (!IsActive)
        {
            _isActive = true;
            _cancellationTokenSource = new CancellationTokenSource();
            ProduceItemTask(_cancellationTokenSource.Token);
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            _isActive = false;
            _cancellationTokenSource?.Cancel();
        }
    }

    private void OnDestroy()
    {
        Deactivate();
    }

    private async Task ProduceItemTask(CancellationToken cancellationToken)
    {
        float progress = 0f;

        while (IsActive && !_cancellationTokenSource.IsCancellationRequested)
        {
            if (progress >= 1f)
            {
                int itemsProduced = (int)progress;
                progress -= itemsProduced;

                for (int i = 0; i < itemsProduced; i++)
                {
                    SpawnItem();
                }
            }

            progress += _spawnerData.SpawnData.SpawnRate * Time.deltaTime;

            await Task.Yield();
        }
    }

    private void SpawnItem()
    {
        _targetInventory.AddItem(_spawnerData.SpawnData.Item);
        Debug.Log(_spawnerData.Name + "spawned item: " + _spawnerData.SpawnData.Item.Name);
    }
}
