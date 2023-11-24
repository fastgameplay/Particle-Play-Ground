using UnityEngine;
using TMPro;
using System;
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextUpdater : MonoBehaviour
{
    [SerializeField] private SO_EventFloat _onDistanceUpdate;
    private TextMeshProUGUI _text;

    private void Awake(){
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateText(float value){
        _text.text = $"Distance: {value.ToString("F3")}";
    }

    private void OnEnable(){
        _onDistanceUpdate.Event += UpdateText;
    }

    private void OnDisable(){
        _onDistanceUpdate.Event -= UpdateText;
    }
}
