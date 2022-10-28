using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    private MyInputs _myInputs;

    public static InputManager Instance;

    public static event Action onMouseClicked;
    public static event Action onMouseHold;
    public static event Action onMouseCanceled;

    private Vector2 _delta;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this.gameObject);
        
        _myInputs = new MyInputs();

    }


    private void OnEnable()
    {
        _myInputs.Enable();
    }

    private void OnDisable()
    {
        _myInputs.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        _myInputs.PlayerMovements.LeftMouseButton.started += MouseClicked;
        _myInputs.PlayerMovements.LeftMouseButton.performed += MousePerformed;
        _myInputs.PlayerMovements.LeftMouseButton.canceled += MouseCanceled;

    }

    private void Update()
    {
        _delta = _myInputs.PlayerMovements.MouseMovementDelta.ReadValue<Vector2>();
    }

    private void MouseCanceled(InputAction.CallbackContext obj)
    {
        onMouseCanceled?.Invoke();
    }

    private void MousePerformed(InputAction.CallbackContext obj)
    {
        onMouseHold?.Invoke();
    }

    private void MouseClicked(InputAction.CallbackContext obj)
    {
        onMouseClicked?.Invoke();
    }
    

    public void MouseDeltaMovement(ref Vector2 position)
    {
        // Debug.Log($"Mouse Delta: {_myInputs.PlayerMovements.MouseMovementDelta.ReadValue<Vector2>()}");
        position = _delta;
    }

    public Vector3 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }


}
