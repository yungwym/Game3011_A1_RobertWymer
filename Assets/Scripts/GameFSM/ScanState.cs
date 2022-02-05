using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScanState : GameState
{
    private TextMeshProUGUI scanText;


    public GameStateId GetId()
    {
        return GameStateId.ScanState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Scan State");

        gameController.scanModeButton.SetActive(false);
        gameController.extractModeButton.SetActive(true);

        gameController.scanText.SetActive(true);
        gameController.scanNumText.SetActive(true);

        scanText = gameController.scanNumText.GetComponent<TextMeshProUGUI>();
    }

    public void Update(GameController gameController)
    { 
        scanText.text = gameController.tileManager.remainingScans.ToString();  
    }

    public void Exit(GameController gameController)
    {

    }
}
