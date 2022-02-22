using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficult : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
