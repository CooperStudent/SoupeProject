using UnityEngine;
using System.Collections; 

public class EnemyCollision : MonoBehaviour
{
    private GameTimer gameTimer;
    private GameManager gameManager;

    private void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleCollision();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        StartCoroutine(EndGameAfterDelay());
    }

    private IEnumerator EndGameAfterDelay()
    {
        yield return new WaitForSeconds(0.25f);
        gameTimer.StopTimer();
        gameManager.LoseGame();
    }
}
