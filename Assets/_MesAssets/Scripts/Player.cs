using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Player : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _teleportationInteractor = default;

    private ActionBasedControllerManager[] _actionBasedControllerManagers;  // accéder au snap turn des contrôleurs
    private DynamicMoveProvider _dynamicMoveProvider;

    private void Awake()
    {
        _actionBasedControllerManagers = GetComponentsInChildren<ActionBasedControllerManager>();
        _dynamicMoveProvider = GetComponentInChildren<DynamicMoveProvider>();
    }

    private void Start()
    {
        GererGameStateChanged(GameManagerMainMenu.Instance.State);
        GameManagerMainMenu.OnGameStateChanged += GererGameStateChanged; //listener sur le event du gamestate
    }

    private void GererGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Start:
                MouvementsJoueur(false);
                break;
            case GameState.Play:
                MouvementsJoueur(true);
                break;
            case GameState.Pause:
                MouvementsJoueur(false);
                break;
            default:
                break;

        }
        
    }

    private void MouvementsJoueur(bool canMove)
    {
        if (canMove)
        {
            _dynamicMoveProvider.moveSpeed = 1;
        }
        else
        {
            _dynamicMoveProvider.moveSpeed = 0;
        }

        _teleportationInteractor.enabled = canMove;
    }

    public bool ChangerSnapTurn()
    {
        
        foreach( var controllerManager in _actionBasedControllerManagers )
        {
            controllerManager.smoothTurnEnabled = !controllerManager.smoothTurnEnabled;
        }

        return !_actionBasedControllerManagers[0].smoothTurnEnabled;
        
    }
}
