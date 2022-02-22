using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;
    public List<GameObject> targets;
    private bool gameOver;
    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        this.gameOverText.gameObject.SetActive(false);
        this.restartButton.gameObject.SetActive(false);
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puntuacion: " + score;
    }

    public void GameOver()
    {
        this.gameOver = true;
        this.gameOverText.gameObject.SetActive(true);
        this.restartButton.gameObject.SetActive(true);
    }

    public bool isGameOver()
    {
        return this.gameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
