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

    private CancellationTokenSource _cancellationTokenSource;

    public DemandPoint(DemandData data)
    {
        _data = data;
    }

    public async Task StartNewDemand()
    {
        CancelCurrentDemand();

        _cancellationTokenSource = new CancellationTokenSource();
        await DelayTask(_cancellationTokenSource.Token);

        if (!_cancellationTokenSource.IsCancellationRequested)
        {
            DemandStarted?.Invoke(this);
            await DemandTask(_cancellationTokenSource.Token);
        }

        if (_cancellationTokenSource.IsCancellationRequested)
        {
            CancelDemand();
        }
        else
        {
            CompleteDemand();
            StartNewDemand();
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

    private async Task DelayTask(CancellationToken cancellationToken)
    {
        float timer = UnityEngine.Random.Range(_data.MinTime, _data.MaxTime);

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            await Task.Yield();
        }
    }

    private async Task DemandTask(CancellationToken cancellationToken)
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

    private void CancelCurrentDemand()
    {
        _cancellationTokenSource?.Cancel();
    }
}
