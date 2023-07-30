using Sirenix.OdinInspector;
using UnityEngine;

public class GameplayManager : SerializedMonoBehaviour
{
    [SerializeField]
    private IResetable[] _resetables;

    [SerializeField]
    private DemandPointAvatar[] _demandPointAvatars;

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
    }

    private void ResetGameState()
    {
        foreach (IResetable resetable in _resetables)
        {
            resetable.ResetMe();
        }
    }
}
