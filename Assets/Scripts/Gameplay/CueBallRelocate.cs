using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallRelocate : MonoBehaviour
{
    // at the beginning of the 
    private const float STARTlINE = 2.0f;

    [SerializeField]
    private LayerMask _placeableArea;

    [SerializeField, Range(0.1f, 3f)]
    private float _raycastLength;

    // === FOR GAME START ===
    private Rigidbody _rb;
    private float _currentPos;
    private Vector2 _setStartPosition;
    private Camera _main;
    private bool _canMove;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _main = Camera.main;
    }

    private void OnEnable()
    {
        InputManager.onMouseHold += SetCueBallPosition;
        InputManager.onMouseCanceled += ReleaseCueBall;
    }

    private void OnDisable()
    {
        InputManager.onMouseHold -= SetCueBallPosition;
        InputManager.onMouseCanceled -= ReleaseCueBall;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{_setStartPosition}");
        InputManager.Instance.MouseDeltaMovement(ref _setStartPosition);
        _currentPos = _setStartPosition.y;
        //_currentPos = Mathf.Clamp(_currentPos, -STARTlINE, STARTlINE);

        if (_canMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z + _currentPos, -STARTlINE, STARTlINE));
        }
    }

    private void SetCueBallPosition()
    {
        Ray ray = _main.ScreenPointToRay(InputManager.Instance.GetMousePosition());
        RaycastHit hit;
        _rb.isKinematic = true;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.name == this.gameObject.name)
            {
                _canMove = true;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            }
        }




    }

    private void ReleaseCueBall()
    {
        _rb.isKinematic = false;
        _canMove = false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * _raycastLength, Color.red);
    }
}
