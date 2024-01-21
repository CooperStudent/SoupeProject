using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int totalCollectibles = 3;
    public TextMeshProUGUI gameStatusText;
    private GameTimer gameTimer;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource backgroundMusic;
    private HashSet<int> collectedCollectibles;
    public GameObject[] enemies; 

    private void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        backgroundMusic = gameTimer.backgroundMusic;
        gameStatusText.text = "";
        collectedCollectibles = new HashSet<int>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
    }

    public void CollectItem(int collectibleID)
    {
        collectedCollectibles.Add(collectibleID);
        if (collectedCollectibles.Count >= totalCollectibles)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameTimer.StopTimer();
        gameStatusText.text = "YOU WIN!";
        backgroundMusic.Stop();
        winSound.Play();
        DisablePlayerMovement();
        DisableEnemies();
        StartCoroutine(ReturnToMainMenu());
    }

    public void LoseGame()
    {
        gameTimer.StopTimer();
        gameStatusText.text = "GAME OVER\nTRY AGAIN!";
        backgroundMusic.Stop();
        loseSound.Play();
        DisablePlayerMovement();
        DisableEnemies();
        StartCoroutine(ReturnToMainMenu());
    }

    private void DisablePlayerMovement()
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    private void DisableEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false); 
        }
    }
    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2.0f); 
        SceneManager.LoadScene("MainMenu"); 
    }
}