using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName ="Camera Value",menuName = "Custom SO/Variables/Camera")]
public class CameraValue : ResetableScriptableObject
{
    public Camera Value;
    public override void ResetMe()
    {
    }
}
