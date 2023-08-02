using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandBubblesController : MonoBehaviour
{
    [SerializeField]
    private DemandBubble _demandBubblePrefab;
    [SerializeField]
    private CameraValue _gameplayCamera;
    [SerializeField]
    private DemandPointAvatarCollection _demandPointAvatarCollection;

    private Dictionary<DemandPoint, DemandBubble> _bubblesDictionary;

    private void Awake()
    {
        _bubblesDictionary = new Dictionary<DemandPoint, DemandBubble>();
    }

    public void ShowBubbleForDemandPoint(DemandPoint demandPoint)
    {
        DemandBubble bubble = null;

        //TODO use object pool
        if (_bubblesDictionary.ContainsKey(demandPoint))
        {
            bubble = _bubblesDictionary[demandPoint];
        }

        if (bubble == null)
        {
            bubble = Instantiate(_demandBubblePrefab, transform);
            _bubblesDictionary.Add(demandPoint, bubble);
        }

        DemandPointAvatar avatar = _demandPointAvatarCollection.Value[demandPoint];
        bubble.transform.position = _gameplayCamera.Value != null && avatar != null ? 
                                    _gameplayCamera.Value.WorldToScreenPoint(avatar.transform.position) 
                                    : Vector3.zero;

        bubble.Show(demandPoint.Data.DemandData);
    }

    public void HideBubbleForDemandPoint(DemandPoint avatar)
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
