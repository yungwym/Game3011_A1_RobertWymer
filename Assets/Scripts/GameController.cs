using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //Tile Manager
    public TileManager tileManager;

    public GameObject GridArea;

    //State Machine Variables 
    public StateMachine stateMachine;
    public GameStateId initialState;

    //UI Objects
    public Canvas startCanvas;
    public Canvas gameCanvas;
    public Canvas endCanvas;

    public GameObject scanModeButton;
    public GameObject extractModeButton;

    public GameObject scanText;
    public GameObject scanNumText;

    public GameObject extractText;
    public GameObject extractNumText;

    public TextMeshProUGUI resourceNumText;

    public TextMeshProUGUI finalResourceText;

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
        stateMachine.RegisterState(new EndState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void EnterScanMode()
    {
        stateMachine.ChangeState(GameStateId.ScanState);
    }

    public void EnterExtractMode()
    {
        stateMachine.ChangeState(GameStateId.ExtractState);
    }


    


}
