using CW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowManager : MonoSingleton<CrowManager>
{
    [SerializeField] private Transform _crowStartTrm;
    [SerializeField] private Transform _crowEndTrm;
    public Vector2 crowStartPos => _crowStartTrm.position;
    public Vector2 crowEndPos => _crowEndTrm.position;



}
