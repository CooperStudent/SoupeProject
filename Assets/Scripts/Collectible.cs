using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound();
            Invoke("DeactivateCollectible", audioSource.clip.length);
            FindObjectOfType<GameManager>().CollectItem(GetInstanceID());
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void DeactivateCollectible()
    {
        gameObject.SetActive(false);
    }
}
