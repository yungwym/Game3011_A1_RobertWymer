using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateId
{
    BeginState,
    IdleState,
    ScanState,
    ExtractState
}

public interface GameState
{
    GameStateId GetId();
    void Enter(GameController gameController);
    void Update(GameController gameController); 
    void Exit(GameController gameController);
}
