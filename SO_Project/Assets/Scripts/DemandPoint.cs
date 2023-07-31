using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DemandPoint
{
    public Action<DemandPoint> DemandCompleted;
    public Action<DemandPoint> DemandCanceled;
    public Action<DemandPoint> DemandStarted;
    public Action<DemandPoint, Item> ItemRejected;

    private DemandData _data;
    private bool _itemAccepted;

    private bool _isActive;
    public bool IsActive => _isActive;

    private CancellationTokenSource _cancellationTokenSource;

    private GameEvent _itemDeliveredItem;

    public enum State
    {
        Idle,
        AwaitingItem
    }

    private State _state;

    public DemandPoint(DemandData data, GameEvent itemDeliveredItem)
    {
        _data = data;
        _isActive = false;
        _itemDeliveredItem = itemDeliveredItem;
    }

    public void Activate()
    {
        if (!IsActive)
        {
            _isActive = true;
            DemandTask();
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            _isActive = false;
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }

    private async Task DemandTask()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        while (IsActive)
        {
            _state = State.Idle;
            _itemAccepted = false;
            await AwaitDelayTask(_cancellationTokenSource.Token);

            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                DemandStarted?.Invoke(this);
                _state = State.AwaitingItem;
                await AwaitItemTask(_cancellationTokenSource.Token);
            }
            _state = State.Idle;

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

    public void DeliverItem(Item item)
    {
        if (_state == State.AwaitingItem && item == _data.Item)
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
        _itemDeliveredItem?.Raise();
    }

    private void RejectItem(Item item)
    {
        ItemRejected?.Invoke(this, item);
    }
}
