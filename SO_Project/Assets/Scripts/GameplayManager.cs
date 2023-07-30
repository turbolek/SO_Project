using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private DemandPointAvatar[] _demandPointAvatars;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        foreach (DemandPointAvatar demandPointAvatar in _demandPointAvatars)
        {
            demandPointAvatar.Activate();
        }
    }
}
