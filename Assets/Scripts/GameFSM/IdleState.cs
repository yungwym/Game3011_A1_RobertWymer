using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GameState
{
    
    public GameStateId GetId()
    {
        return GameStateId.IdleState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Idle State");

        gameController.gameCanvas.enabled = true;
        gameController.startCanvas.enabled = false;
        gameController.endCanvas.enabled = false;

        gameController.extractModeButton.SetActive(false);

        gameController.scanText.SetActive(false);
        gameController.scanNumText.SetActive(false);

        gameController.tileManager.GenerateEmptyGrid(32,64);
    }

    public void Update(GameController gameController)
    {

    }

    public void Exit(GameController gameController)
    {

    }

}
