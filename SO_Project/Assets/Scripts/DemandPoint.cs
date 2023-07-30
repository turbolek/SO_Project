using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DemandPoint : MonoBehaviour
{
    public Action<DemandPoint> DemandCompleted;
    public Action<DemandPoint> DemandCanceled;
    public Action<DemandPoint> DemandStarted;
    public Action<DemandPoint, Item> ItemRejected;

    private DemandData _data;
    private bool _itemAccepted;

    public bool IsActive { get; private set; }

    private CancellationTokenSource _cancellationTokenSource;

    public DemandPoint(DemandData data)
    {
        _data = data;
        IsActive = false;
    }

    public void Activate()
    {
        if (!IsActive)
        {
            IsActive = true;
            DemandTask();
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            IsActive = false;
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }

    private async Task DemandTask()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        while (IsActive)
        {
            await AwaitDelayTask(_cancellationTokenSource.Token);

            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                DemandStarted?.Invoke(this);
                await AwaitItemTask(_cancellationTokenSource.Token);
            }

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                CancelDemand();
            }
            else
            {
                CompleteDemand();
            }
        }
    }

    private void CancelDemand()
    {
        DemandCanceled?.Invoke(this);
    }

    private void CompleteDemand()
    {
        DemandCompleted?.Invoke(this);
    }

    private async Task AwaitDelayTask(CancellationToken cancellationToken)
    {
        float timer = UnityEngine.Random.Range(_data.MinTime, _data.MaxTime);

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            await Task.Yield();
        }
    }

    private async Task AwaitItemTask(CancellationToken cancellationToken)
    {
        while (!_itemAccepted)
        {
            await Task.Yield();
        }
    }

    public void OnItemReceived(Item item)
    {
        if (item == _data.Item)
        {
            AcceptItem(item);
        }
        else
        {
            RejectItem(item);
        }
    }

    private void AcceptItem(Item item)
    {
        _itemAccepted = true;
    }

    private void RejectItem(Item item)
    {
        ItemRejected?.Invoke(this, item);
    }
}
