using Sirenix.OdinInspector;
using UnityEngine;

public class GameplayManager : SerializedMonoBehaviour
{
    [SerializeField]
    private IResetable[] _resetables;

    [SerializeField]
    private DemandPointAvatar[] _demandPointAvatars;

    [SerializeField]
    private ItemSpawner[] _itemSpawners;

    private void Start()
    {
        ResetGameState();
        StartGame();
    }

    private void StartGame()
    {
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
}
