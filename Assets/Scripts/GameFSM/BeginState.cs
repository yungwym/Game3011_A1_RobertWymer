using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : GameState
{
    public GameStateId GetId()
    {
        return GameStateId.BeginState;
    }

    public void Enter(GameController gameController)
    {
       Debug.Log("Entered Begin State");

       gameController.startCanvas.enabled = true;
       gameController.gameCanvas.enabled = false;
    }

    public void Update(GameController gameController)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameController.stateMachine.ChangeState(GameStateId.IdleState);
        }
    }

    public void Exit(GameController gameController)
    {

    }
}
