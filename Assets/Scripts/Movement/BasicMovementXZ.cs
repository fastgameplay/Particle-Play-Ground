using UnityEngine;

public class BasicMovementXZ : MonoBehaviour
{
    [SerializeField] private SO_EventVector2 _onMovement;
    [SerializeField] private SO_EventVector3 _onPositionUpdate;
    //TODO: transfer to scriptable for proper space allocation
    [SerializeField] private float _speed;
    private Vector3 _movementDirection;
    private void Awake(){
        _onPositionUpdate.Event?.Invoke(transform.position);
    }

    private void Update(){
        HandleMovement();
    }

    private void HandleMovement(){
        if(_movementDirection == Vector3.zero) return;
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
        _onPositionUpdate.Event?.Invoke(transform.position);
    }

    private void OnMovement(Vector2 value){
        _movementDirection = new Vector3(value.x, 0, value.y);
    }

    private void OnEnable(){
        _onMovement.Event += OnMovement;
    }

    private void OnDisable(){
        _onMovement.Event -= OnMovement;
    }
}
