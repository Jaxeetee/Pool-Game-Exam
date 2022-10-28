using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlong : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField, Range(5f, 100f), Tooltip("speed multiplier for rotating around the cue.")]
    private float _rotationSensitivity;


    [SerializeField]
    private bool _startRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startRotating)
        // must change rotation due to mouse position/touch screen
        transform.RotateAround(_target.position, Vector3.up, 40 * Time.deltaTime);
    }
}
