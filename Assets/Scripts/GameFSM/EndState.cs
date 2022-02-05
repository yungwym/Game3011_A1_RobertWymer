using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : GameState
{
    public GameStateId GetId()
    {
        return GameStateId.EndState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered End State");

        gameController.startCanvas.enabled = false;
        gameController.gameCanvas.enabled = false;

        gameController.endCanvas.enabled = true;

        gameController.GridArea.SetActive(false);
    }

    public void Update(GameController gameController)
    {
        gameController.finalResourceText.text = gameController.tileManager.resourcesCollected.ToString();
    }

    public void Exit(GameController gameController)
    {

    }
}
