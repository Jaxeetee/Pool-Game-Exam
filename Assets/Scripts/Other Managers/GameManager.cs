using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField]
    private GameObject _cueStick;

    [SerializeField]
    private Rigidbody _cueBallRB;

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

    private void Start()
    {
        StartCoroutine(ICheckCueBallSpeed());
    }

    private IEnumerator ICheckCueBallSpeed()
    {
        while (true)
        {
            if (!_cueStick.activeSelf)
            {
                if (_cueBallRB.velocity == Vector3.zero)
                {
                    _cueStick.SetActive(true);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void GameStart() => onGameStart?.Invoke();
    public void GameStop() => onGameStop?.Invoke(); 
}
