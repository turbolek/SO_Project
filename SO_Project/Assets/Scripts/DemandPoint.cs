using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DemandPoint
{
    private DemandPointData _data;
    public DemandPointData Data => _data;
    private bool _itemAccepted;

    private bool _isActive;
    public bool IsActive => _isActive;

    private CancellationTokenSource _cancellationTokenSource;

    public enum State
    {
        Idle,
        AwaitingItem
    }

    private State _state;

    public DemandPoint(DemandPointData data)
    {
        _data = data;
        _isActive = false;
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
                _data.DemandStartedEvent?.Raise(this);
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
    }

    private void CompleteDemand()
    {
        _data.DemandCompletedEvent?.Raise(this);
    }

    private async Task AwaitDelayTask(CancellationToken cancellationToken)
    {
        float timer = UnityEngine.Random.Range(_data.DemandData.MinTime, _data.DemandData.MaxTime);

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
        if (_state == State.AwaitingItem && item == _data.DemandData.Item)
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
        _data.ItemDeliveredEvent?.Raise(item);
    }

    private void RejectItem(Item item)
    {
        _data.ItemRejectedEvent?.Raise(item);
    }
}
