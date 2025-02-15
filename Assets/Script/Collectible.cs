using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    [SerializeField] private AudioClip collectibleSound;
    [SerializeField] private float volume = 1.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            PlaySoundAndDestroy();
        }
    }

    void PlaySoundAndDestroy()
    {
        if (collectibleSound != null)
        {
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position, volume);
        }
        Destroy(gameObject);
    }
}
