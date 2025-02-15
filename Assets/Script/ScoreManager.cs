using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Clopes : " + score;
        Debug.Log("Score mis à jour : " + score);
    }

    public void HideScoreInGame()
    {
        scoreText.gameObject.SetActive(false);
    }
}
