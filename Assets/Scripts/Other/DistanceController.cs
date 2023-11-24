using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private SO_EventVector3 _onFirstPlayerPositionUpdate;
    [SerializeField] private SO_EventVector3 _onSecondPlayerPositionUpdate;
    [SerializeField] private SO_EventFloat _onDistanceUpdate;
    private Vector3 _firstPlayerPosition;
    private Vector3 _secondPlayerPosition;
    private bool _hasChanged;

    private void Update(){
        HandleCalculations();
    }

    private void HandleCalculations(){
        if(!_hasChanged) return;
        _onDistanceUpdate.Event?.Invoke(
            Vector3.Distance(_firstPlayerPosition,_secondPlayerPosition)
        );
    }

    private void OnFirstPlayerPositionUpdate(Vector3 value){
        _firstPlayerPosition = value;
        _hasChanged = true;
    }

    private void OnSecondPlayerPositionUpdate(Vector3 value){
        _secondPlayerPosition = value;
        _hasChanged = true;
    }

    void OnEnable(){
        _onFirstPlayerPositionUpdate.Event += OnFirstPlayerPositionUpdate;
        _onSecondPlayerPositionUpdate.Event += OnSecondPlayerPositionUpdate;
    }
    
    void OnDisable(){
        _onFirstPlayerPositionUpdate.Event -= OnFirstPlayerPositionUpdate;
        _onSecondPlayerPositionUpdate.Event -= OnSecondPlayerPositionUpdate;
    }
}
