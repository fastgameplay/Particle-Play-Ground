using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private SO_EventFloat _onDistanceUpdate;
    [SerializeField] private GameObject _sphereHodler;
    private bool sphereState{
        get => _sphereHodler.activeSelf;
        set {
            if(sphereState != value) _sphereHodler.SetActive(value);
        }
    }

    private void OnDistanceUpdate(float distance){
        if(distance < 1f) {
            ChangeScene();
            return;
        }
        if(distance < 2f) {
            sphereState = true;
            return;
        }
        sphereState = false;
    }

    private void ChangeScene(){
        SceneManager.LoadScene(1);
    }

    private void OnEnable(){
        _onDistanceUpdate.Event += OnDistanceUpdate;
    }


    private void OnDisable(){
        _onDistanceUpdate.Event -= OnDistanceUpdate;
    }
}
