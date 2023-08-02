using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : SerializedMonoBehaviour
{
    [SerializeField]
    private IResetable[] _resetables;

    private List<DemandPointAvatar> _demandPointAvatars = new List<DemandPointAvatar>();

    [SerializeField]
    private ItemSpawner[] _itemSpawners;

    //TODO could be replaced with enum or even SO for easy extension to more gameplay states
    private bool _gameStarted;

    private void Start()
    {
        ResetGameState();
        StartGame();
    }

    private void StartGame()
    {
        _gameStarted = true;

        foreach (DemandPointAvatar demandPointAvatar in _demandPointAvatars)
        {
            demandPointAvatar.Initialize();
            demandPointAvatar.Activate();
        }

        foreach (ItemSpawner itemSpawner in _itemSpawners)
        {
            itemSpawner.Activate();
        }
    }

    private void ResetGameState()
    {
        foreach (IResetable resetable in _resetables)
        {
            resetable.ResetMe();
        }
    }

    public void RegisterDemandPointAvatar(DemandPointAvatar avatar)
    {
        _demandPointAvatars.Add(avatar);

        if (_gameStarted)
        {
            avatar.Activate();
        }
    }
}
