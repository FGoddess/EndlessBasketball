using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDirection;
    [SerializeField] private int _score;
    [SerializeField] private bool _isDelay = false;
    [SerializeField] private bool _isPlayerAlive;

    public delegate void ChangeBarrierPosition(Vector2 pos);
    public static event ChangeBarrierPosition OnVelocityChanged;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerControl();
        ScoreChange();
        BarrierPositionChange();

        if (!_isPlayerAlive)
        {
            GameManager.Instance.UpdateHighScore(_score);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRB.simulated = false;
        }

    }

    private void BarrierPositionChange()
    {
        if (_playerRB.velocity.y > 0)
        {
            if (OnVelocityChanged != null)
                OnVelocityChanged(transform.position);
        }
    }

    private void ScoreChange()
    {
        if (transform.position.y > 0 && _score < transform.position.y)
        {
            _score = (int)transform.position.y + 1;
            GameManager.Instance.UpdateScore(_score);
        }
    }

    private void PlayerControl()
    {
        if (Input.GetMouseButtonDown(0) && !_isDelay)
        {
            _playerRB.velocity = new Vector2(0, 0);
            _playerRB.AddForce(new Vector2(_jumpDirection, _jumpForce), ForceMode2D.Impulse);
            StartCoroutine("InputDelayRoutine");
        }
    }

    private IEnumerator InputDelayRoutine()
    {
        _isDelay = true;
        yield return new WaitForSeconds(.3f);
        _isDelay = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            _jumpDirection *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.AddCoins();
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BottomBarrier"))
        {
            //Time.timeScale = 0;
            //_isPlayerAlive = false;
        }
    }
}
