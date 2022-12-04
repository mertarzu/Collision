using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SphereController _sphereController;
    [SerializeField] ScreenManager _screenManager;
   
    private GameState _gameState;
    enum GameState
    {
        Idle,
        Gameplay
    }

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {   
        _screenManager.Initialize();
        _sphereController.Initialize();
        SetIdleState();
        
    }

    public void StartGame()
    {     
        _sphereController.StartGame();      
        SetGamePlayState();
    }

    void SetIdleState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Idle;   
        _screenManager.Show((int)_gameState);
    }

    void SetGamePlayState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Gameplay;    
        _screenManager.Show((int)_gameState);
    }
}
