using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = Vector2.right * _movementSpeed;

        if (transform.position.x > GameManager.Instance.ScreenMaxX + 1f)
            gameObject.SetActive(false);
    }
}
