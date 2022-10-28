using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Mouse Position: {_myInputs.PlayerMovements.MouseMovementPosition.ReadValue<Vector2>()}");
        //Debug.Log($"Mouse Delta: {_myInputs.PlayerMovements.MouseMovementDelta.ReadValue<Vector2>()}");
    }
}
