using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlong : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField, Range(5f, 100f), Tooltip("speed multiplier for rotating around the cue.")]
    private float _rotationSensitivity;

    private Vector2 _mouseRot;
    private Vector3 _targetRotation;
    private Quaternion _lookRotation;

    public bool startRotating = false;
    // Start is called before the first frame update



    private void OnEnable()
    {
        //GameManager.onGameStart += EnableRotatation;
        //GameManager.onGameStop += DisableRotation;
    }

    private void OnDisable()
    {
        //GameManager.onGameStart -= EnableRotatation;
        //GameManager.onGameStop -= DisableRotation;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _targetRotation = Vector3.Normalize(_target.position - transform.position);
        _lookRotation = Quaternion.LookRotation(_targetRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotationSensitivity);
        
        if (startRotating)
        {
            InputManager.Instance.MouseDeltaMovement(ref _mouseRot);
            // must change rotation due to mouse position/touch screen
            transform.RotateAround(_target.position, Vector3.up, _rotationSensitivity * _mouseRot.x * Time.deltaTime);
        }

       
    }

    private void EnableRotatation()
    {
        startRotating = true;
    }

    private void DisableRotation()
    {
        startRotating = false;
    }
}
