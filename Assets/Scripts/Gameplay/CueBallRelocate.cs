using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallRelocate : MonoBehaviour
{
    [SerializeField]
    private LayerMask _placeableArea;

    [SerializeField, Range(0.1f, 3f)]
    private float _raycastLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, _raycastLength, _placeableArea))
        {
            Debug.Log("Detected Placeable!");
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * _raycastLength, Color.red);
    }
}
