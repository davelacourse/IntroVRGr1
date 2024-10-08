using System;
using UnityEngine;

public enum GameState
{
    Start,
    Play,
    Pause,
    Quit
}

public class GameManagerMainMenu : MonoBehaviour
{
    // Singleton

    public static GameManagerMainMenu Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static event Action<GameState> OnGameStateChanged;
    private GameState _state;
    public GameState State => _state; //Accesseur

    private void Start()
    {
        UpdateGameState(GameState.Start);
        GameManagerMainMenu.OnGameStateChanged += UpdateGameState;
    }

    private void OnDestroy()
    {
        GameManagerMainMenu.OnGameStateChanged -= UpdateGameState;
    }

    public void UpdateGameState(GameState state)
    {

        if (state == _state) return;

        _state = state;

        if(_state == GameState.Quit) 
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            } 
        
        
        OnGameStateChanged?.Invoke(state);
    }

}
