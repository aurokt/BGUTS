using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    Rigidbody2D rb;

    int score = 0;
    int lives = 5;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;

    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    int brickCount;

    private bool ballStuck = true;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        initialPosition = transform.position;
        brickCount = FindObjectOfType<Level>().transform.childCount;
    }

    void Update()
    {
        if (ballStuck)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * 10f;
                ballStuck = false;
            }
        }
        else
        {
            if (transform.position.y < minY)
            {
                if (lives <= 0)
                {
                    GameOver();
                }
                else
                {
                    ResetBall();
                    lives--;
                    livesImage[lives].SetActive(false);
                }
            }

            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("000");
            brickCount--;
            if (brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }

    void ResetBall()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        ballStuck = true;
    }
}
