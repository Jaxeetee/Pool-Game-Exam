using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public static event Action onGameStart;
    public static event Action onGameStop;
    public static event Action onAim;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(Instance);



    }

    

    public void GameStart() => onGameStart?.Invoke();
    public void GameStop() => onGameStop?.Invoke(); 
}
