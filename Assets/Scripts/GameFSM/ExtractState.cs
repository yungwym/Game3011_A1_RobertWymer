using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExtractState : GameState
{
    private TextMeshProUGUI extractText;

    public GameStateId GetId()
    {
        return GameStateId.ExtractState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Extract State");

        gameController.scanModeButton.SetActive(false);
        gameController.extractModeButton.SetActive(false);

        gameController.scanText.SetActive(false);
        gameController.scanNumText.SetActive(false);

        gameController.extractText.SetActive(true);
        gameController.extractNumText.SetActive(true);

        extractText = gameController.extractNumText.GetComponent<TextMeshProUGUI>();
    }

    public void Update(GameController gameController)
    {
        extractText.text = gameController.tileManager.remainingExtracts.ToString();

        gameController.resourceNumText.text = gameController.tileManager.resourcesCollected.ToString();
    }

    public void Exit(GameController gameController)
    {

    }
}
