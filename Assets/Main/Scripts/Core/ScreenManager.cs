using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] List<UIScreen> _uiScreens;
    enum Screen
    {
        Idle,
        Gameplay
    }

    public void Initialize()
    {
        foreach (var uiScreen in _uiScreens) uiScreen.Initialize();
        
        IdleScreen idleScreen = (IdleScreen)_uiScreens[(int)Screen.Idle]; ;
        idleScreen.OnPlayPressed = StartGame;

    }

    void StartGame()
    {
        _gameManager.StartGame();
    }

    public void Show(int screen)
    {
        _uiScreens[screen].Show();
    }

    public void Hide(int screen)
    {
        _uiScreens[screen].Hide();
    }

}
