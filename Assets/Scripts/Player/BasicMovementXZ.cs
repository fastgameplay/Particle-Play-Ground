using UnityEngine;

public class BasicMovementXZ : MonoBehaviour
{
    [SerializeField] private SO_PlayerSettings _playerSettings;
    private Vector3 _movementDirection;

    private void Awake(){
        _playerSettings.OnPositionUpdate?.Invoke(transform.position);
    }

    private void Update(){
        HandleMovement();
    }

    private void HandleMovement(){
        if(_movementDirection == Vector3.zero) return;
        transform.Translate(_movementDirection * _playerSettings.Speed * Time.deltaTime);
        _playerSettings.OnPositionUpdate?.Invoke(transform.position);
    }

    private void OnMovement(Vector2 value){
        _movementDirection = new Vector3(value.x, 0, value.y);
    }

    private void OnEnable(){
        _playerSettings.OnMovement += OnMovement;
    }

    private void OnDisable(){
        _playerSettings.OnMovement -= OnMovement;
    }
}
