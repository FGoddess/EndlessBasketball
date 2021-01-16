using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDirection;
    [SerializeField] private int score;
    [SerializeField] private bool isDelay = false;
    [SerializeField] private bool isPlayerAlive;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDelay)
        {
            playerRB.velocity = new Vector2(0,0);
            playerRB.AddForce(new Vector2(jumpDirection, jumpForce), ForceMode2D.Impulse);
            StartCoroutine("InputDelayRoutine");
        }

        if(transform.position.y > 0 && score < transform.position.y)
        {
            score = (int)transform.position.y + 1;
            GameManager.Instance.UpdateScore(score);
            Debug.Log(score);
        }
    }

    private IEnumerator InputDelayRoutine()
    {
        isDelay = true;
        yield return new WaitForSeconds(.3f);
        isDelay = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            jumpDirection *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.AddCoins();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
        }
    }
}
