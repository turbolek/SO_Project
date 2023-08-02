using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCameraSetter : MonoBehaviour
{
    [SerializeField]
    private CameraValue _gameplayCamera;
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        _gameplayCamera.Value = _camera;
    }
}
