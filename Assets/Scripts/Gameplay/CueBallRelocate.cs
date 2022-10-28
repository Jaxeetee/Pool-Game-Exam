using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallRelocate : MonoBehaviour
{
    // at the beginning of the 
    private const float STARTlINE = 2.0f;
    private Rigidbody _rb;

    [SerializeField]
    private LayerMask _placeableArea;

    [SerializeField, Range(0.1f, 3f)]
    private float _raycastLength;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.isKinematic = true;    
    }




    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, _raycastLength, _placeableArea))
        {
           // Debug.Log("Detected Placeable!");
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * _raycastLength, Color.red);
    }
}
