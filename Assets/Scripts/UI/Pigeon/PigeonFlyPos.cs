using System.Collections.Generic;
using UnityEngine;

public class PigeonFlyPos : MonoBehaviour
{
    [SerializeField] List<RectTransform> _positionList = new List<RectTransform>();

    public List<RectTransform> PositionList { get => _positionList; }
}