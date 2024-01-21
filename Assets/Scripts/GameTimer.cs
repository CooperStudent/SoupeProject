using UnityEngine;
using TMPro;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 10.0f;
    private float startTime = 2.0f;
    private bool timerRunning = false;
    public TextMeshProUGUI timerText;
    public AudioSource backgroundMusic;

    private void Start()
    {
        StartCoroutine(InitialCountdown());
    }

    private IEnumerator InitialCountdown()
    {
        timerText.text = "Get Ready!\n\n\nUse WASD to Move\nCollect 3 Ingredients\nWatch Out for Chickens";
        FindObjectOfType<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(startTime);

        timerRunning = true;
        FindObjectOfType<PlayerMovement>().enabled = true;
        timerText.text = gameTime.ToString("F2");
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError("Background music AudioSource is not assigned!");
        }
    }

    private void Update()
    {
        if (timerRunning)
        {
            gameTime -= Time.deltaTime;
            timerText.text = gameTime.ToString("F2");

            if (gameTime <= 0)
            {
                timerRunning = false;
                FindObjectOfType<GameManager>().LoseGame();
            }
        }
    }

    public void StopTimer()
    {
        timerRunning = false;
        timerText.text = "";
    }
}
