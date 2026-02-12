using UnityEngine;
using System;


[ExecuteAlways]
public class ParallaxController : MonoBehaviour {
    
    [SerializeField] private Transform _previewRef;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void Awake() {
        transform.localPosition = _offset;
    }

    private void Update() {
#if UNITY_EDITOR
        if (!Application.isPlaying && _previewRef) {
            transform.localPosition = _offset + _previewRef.transform.position * _speed;
            
            return;
        }
#endif
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));
    }
}

