using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = Vector2.left * _movementSpeed;

        if (transform.position.x < GameManager.Instance.ScreenMinX - 1)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            GameEvents.ReduceEnemies();
            Destroy(gameObject);
        }
    }
}
