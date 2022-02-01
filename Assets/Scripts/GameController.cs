using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //State Machine Variables 
    public StateMachine stateMachine;
    public GameStateId initialState;

    //UI Objects
    public Canvas startCanvas;
    public Canvas gameCanvas;
    public GameObject scanModeButton;
    public GameObject extractModeButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController Start");

        //State Machine Setup
        stateMachine = new StateMachine(this);
        stateMachine.RegisterState(new BeginState());
        stateMachine.RegisterState(new IdleState());
        stateMachine.RegisterState(new ScanState());
        stateMachine.RegisterState(new ExtractState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void EnterScanMode()
    {

    }

    public void EnterExtractMode()
    {

    }
}
