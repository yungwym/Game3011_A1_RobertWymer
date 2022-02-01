using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public GameState[] states;
    public GameController gameController;
    public GameStateId currentState;

    public StateMachine(GameController gameController)
    {
        this.gameController = gameController;
        int numStates = System.Enum.GetNames(typeof(GameStateId)).Length;

        states = new GameState[numStates];
    }

    public void RegisterState(GameState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public GameState GetState(GameStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(gameController);
    }

    public void ChangeState(GameStateId newGameState)
    {
        GetState(currentState)?.Exit(gameController);
        currentState = newGameState;
        GetState(currentState)?.Enter(gameController);
    }

}
