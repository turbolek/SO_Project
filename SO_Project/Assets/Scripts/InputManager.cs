using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Vector3Value _mousePosition;
    [SerializeField]
    private VoidGameEvent _leftClickEvent;

    // Update is called once per frame
    void Update()
    {
        /* TODO use Unity Input system for event based logic instead of Update
        * Input system variables and events could also be handled by SOs to avoid rigid references 
        */
        _mousePosition.Value = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            _leftClickEvent?.Raise();
        }
    }
}
