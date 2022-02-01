using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractState : GameState
{
    public GameStateId GetId()
    {
        return GameStateId.ExtractState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Extract State");
    }

    public void Update(GameController gameController)
    {

    }

    public void Exit(GameController gameController)
    {

    }
}
