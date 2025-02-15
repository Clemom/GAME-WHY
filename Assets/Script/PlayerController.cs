using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 2f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    private static bool hasStarted = false;

    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private float gameOverVolume = 1.0f;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        startPanel.SetActive(!hasStarted);
        Time.timeScale = hasStarted ? 1 : 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.CompareTag("Ground");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(HandleGameOver());
        }
    }

    IEnumerator HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound, gameOverVolume);
        }

        Time.timeScale = 0;
        yield break;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
        hasStarted = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
