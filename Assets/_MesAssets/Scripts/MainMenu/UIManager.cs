using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenuPanel = default;
    [SerializeField] private GameObject _optionsPanel = default;
    [SerializeField] private TMP_Text _txtSnapTurn = default;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void OnDemarrerClick()
    {
        GameManagerMainMenu.Instance.UpdateGameState(GameState.Play);
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(false);
    }

    public void OnQuitterClick()
    {
        GameManagerMainMenu.Instance.UpdateGameState(GameState.Quit);
    }

    public void OnOptionsClick()
    {
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
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
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }
}
