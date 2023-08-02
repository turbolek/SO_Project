using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Vector3Value _mousePosition;

    // Update is called once per frame
    void Update()
    {
        _mousePosition.Value = Input.mousePosition;
    }
}
