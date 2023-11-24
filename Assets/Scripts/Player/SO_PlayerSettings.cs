using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Settings/Player")]
public class SO_PlayerSettings : ScriptableObject
{
    public Action<Vector2> OnMovement { get => _onMovement.Event; set{ _onMovement.Event = value; }}
    public Action<Vector3> OnPositionUpdate { get => _onPositionUpdate.Event; set{ _onPositionUpdate.Event = value; }}

    public float Speed => _speed;
    [SerializeField] float _speed;

    [Header("Events")]
    [SerializeField] private SO_EventVector2 _onMovement;
    [SerializeField] private SO_EventVector3 _onPositionUpdate;
}
