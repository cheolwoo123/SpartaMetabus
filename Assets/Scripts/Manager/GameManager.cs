using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player { get; private set; }
   [SerializeField] private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;


    
   [SerializeField] private UIManager uiManager;
    public static bool isFirstLoading = true;



    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager>();


        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);

    }



    private void Start()
    {
        _playerResourceController = player.gameObject.GetComponent<ResourceController>();
        

        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    private void SaveHighScore()
    {
        int previousHigh = PlayerPrefs.GetInt("HighWaveScore", 0);
        if (currentWaveIndex > previousHigh)
        {
            PlayerPrefs.SetInt("HighWaveScore", currentWaveIndex);           
            PlayerPrefs.Save();
            Debug.Log("HighWave Score: " + currentWaveIndex); 
        }
    }

   
    public void StartGame()
    {

        uiManager.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);

        uiManager.ChangeWave(currentWaveIndex);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        enemyManager.StopWave();
        uiManager.SetGameOver();
        SaveHighScore();

      

    }

    
    
}
