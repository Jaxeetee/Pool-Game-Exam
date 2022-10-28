using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Camera _main;

    //for targetting
    [SerializeField]
    private Transform _cueBall;


    [SerializeField]
    private float _mouseDragSpeed = 1f;

    private Vector2 _setStartPosition;
    private float _currentPos;
    private bool _canMove;
    private Vector3 _newPos;
    private Vector3 velocity;

    void Start()
    {
        _main = Camera.main;   
    }

    private void OnEnable()
    {
        RollBall.onCollide += DisableThis;
        InputManager.onMouseHold += DragThis;
    }



    private void OnDisable()
    {
        RollBall.onCollide -= DisableThis;
        InputManager.onMouseHold -= DragThis;
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.Instance.MouseDeltaMovement(ref _setStartPosition);
        _currentPos = _setStartPosition.x;

        if (_canMove)
        {
            _newPos = new Vector3 (transform.position.x, -_currentPos, transform.position.z);
        }

    }
    private void DragThis()
    {
        Ray ray = _main.ScreenPointToRay(InputManager.Instance.GetMousePosition());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.name == this.gameObject.name)
            {
                StartCoroutine(IDragging(hit.collider.gameObject));
            }
        }
    }


    private IEnumerator IDragging(GameObject thisObject)
    {
        float initialDistance = Vector3.Distance(thisObject.transform.position, _main.transform.position);
        while (true)
        {
            Ray ray = _main.ScreenPointToRay(InputManager.Instance.GetMousePosition());
            thisObject.transform.position = Vector3.SmoothDamp(thisObject.transform.position, _newPos, ref velocity, _mouseDragSpeed);
            yield return null;
        }
    }
    private void DisableThis()
    {
        this.gameObject.SetActive(false);
    }

}
