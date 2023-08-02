using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandBubblesController : MonoBehaviour
{
    [SerializeField]
    private DemandBubble _demandBubblePrefab;

    [SerializeField]
    private CameraValue _gameplayCamera;

    private Dictionary<DemandPointAvatar, DemandBubble> _bubblesDictionary;

    private void Awake()
    {
        _bubblesDictionary = new Dictionary<DemandPointAvatar, DemandBubble>();
    }

    public void ShowBubbleForAvatar(DemandPointAvatar avatar)
    {
        DemandBubble bubble = null;

        //TODO use object pool
        if (_bubblesDictionary.ContainsKey(avatar))
        {
            bubble = _bubblesDictionary[avatar];
        }

        if (bubble == null)
        {
            bubble = Instantiate(_demandBubblePrefab, transform);
            _bubblesDictionary.Add(avatar, bubble);
        }

        bubble.transform.position = _gameplayCamera.Value != null ? _gameplayCamera.Value.WorldToScreenPoint(avatar.transform.position) : Vector3.zero;
        bubble.Show(avatar.Data.DemandData);
    }

    public void HideBubbleForAvatar(DemandPointAvatar avatar)
    {
        if (_bubblesDictionary.ContainsKey(avatar))
        {
            DemandBubble bubble = _bubblesDictionary[avatar];
            if (bubble != null)
            {
                bubble.Hide();
            }
        }
    }
}
