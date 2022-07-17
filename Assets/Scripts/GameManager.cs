using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int TotalNoOfEnemies = 15;    

    private Vector3 _lowerLeft;
    private Vector3 _upperRight;

    [HideInInspector] public float ScreenMinX;
    [HideInInspector] public float ScreenMaxX;
    [HideInInspector] public float ScreenMinY;
    [HideInInspector] public float ScreenMaxY;

    public override void Awake()
    {
        base.Awake();

        _lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        _upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        ScreenMinX = _lowerLeft.x;
        ScreenMaxX = _upperRight.x;
        ScreenMinY = _lowerLeft.y;
        ScreenMaxY = _upperRight.y;
    }


    private void OnEnable()
    {
        GameEvents.ReduceEnemies += ReduceEnemies;
    }

    private void OnDisable()
    {
        GameEvents.ReduceEnemies -= ReduceEnemies;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(TotalNoOfEnemies <= 0)
        {
            GameEvents.GameComplete();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void ReduceEnemies()
    {
        TotalNoOfEnemies--;
    }
}
