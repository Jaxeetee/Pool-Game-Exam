using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    private MyInputs _myInputs;

    public static InputManager Instance;


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
        _myInputs.PlayerMovements.LeftMouseButton.started += onMouseClicked;
        _myInputs.PlayerMovements.LeftMouseButton.performed += onMousePerformed;
        _myInputs.PlayerMovements.LeftMouseButton.canceled += onMouseCanceled;

    }

    private void onMouseCanceled(InputAction.CallbackContext obj)
    {
        
    }

    private void onMousePerformed(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void onMouseClicked(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Mouse Position: {_myInputs.PlayerMovements.MouseMovementPosition.ReadValue<Vector2>()}");
    }

    public void MouseDeltaMovement(ref Vector2 position)
    {
        Debug.Log($"Mouse Delta: {_myInputs.PlayerMovements.MouseMovementDelta.ReadValue<Vector2>()}");
        position = _myInputs.PlayerMovements.MouseMovementDelta.ReadValue<Vector2>();
    }


}
