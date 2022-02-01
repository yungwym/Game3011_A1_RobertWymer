using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanState : GameState
{
    public GameStateId GetId()
    {
        return GameStateId.ScanState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Scan State");
    }

    public void Update(GameController gameController)
    {

    }

    public void Exit(GameController gameController)
    {

    }
}
