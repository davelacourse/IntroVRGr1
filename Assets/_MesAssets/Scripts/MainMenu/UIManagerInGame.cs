using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManagerInGame : MonoBehaviour
{

    [SerializeField] private GameObject _inGameMenuPanel = default;
    [SerializeField] private GameObject _optionsInGamePanel = default;
    [SerializeField] private TMP_Text _txtSnapTurn = default;

    private Player _player;
    bool _isMenuOpen;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _isMenuOpen = false;
        _inGameMenuPanel.SetActive(false);
        _optionsInGamePanel.SetActive(false);
    }

    public void ToggleMenu()
    {
        if(GameManagerMainMenu.Instance.State != GameState.Start)
        {
            _isMenuOpen = !_isMenuOpen;
            _inGameMenuPanel.SetActive(_isMenuOpen);
            _optionsInGamePanel.SetActive(false);
            if(_isMenuOpen)
            {
                GameManagerMainMenu.Instance.UpdateGameState(GameState.Pause);
            }
            else
            {
                GameManagerMainMenu.Instance.UpdateGameState(GameState.Play);
            }
        }

    }


    public void OnQuitterClick()
    {
        GameManagerMainMenu.Instance.UpdateGameState(GameState.Quit);
    }

    public void OnOptionsClick()
    {
        _inGameMenuPanel.SetActive(false);
        _optionsInGamePanel.SetActive(true);
    }

    public void OnSnapTurnOptionClick()
    {
        bool isSnapTurnOn = _player.ChangerSnapTurn();
        if(isSnapTurnOn) 
        {
            _txtSnapTurn.text = "Snap Turn : On";
        }
        else
        {
            _txtSnapTurn.text = "Snap Turn : Off";
        }
    }

    public void onRetourClick()
    {
        _inGameMenuPanel.SetActive(true);
        _optionsInGamePanel.SetActive(false);
    }
}
