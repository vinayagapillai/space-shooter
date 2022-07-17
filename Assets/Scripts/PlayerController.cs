using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Vector3 _bulletSpawnOffset;
    [SerializeField] private int _initalBulletCount;
    [SerializeField] private List<GameObject> _bulletPool;
    private Transform BulletPoolTransform;

    private Rigidbody2D _rb;

    private void Start()
    {
        GameObject obj = new GameObject("Bullet Pool");
        BulletPoolTransform = obj.GetComponent<Transform>();

        _rb = GetComponent<Rigidbody2D>();
        _bulletPool = new List<GameObject>();

        CreateBulletPool();
    }


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(inputX * _movementSpeed, inputY * _movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
        
    }

    private void ShootBullet()
    {
        Vector3 pos = transform.position + _bulletSpawnOffset;
        GameObject obj = GetFromBulletPool();
        obj.transform.position = pos;
        obj.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameEvents.GameOver();
        }
    }


    private void CreateBulletPool()
    {
        for(int i = 0; i < _initalBulletCount; i++)
        {
            GameObject obj = Instantiate(BulletPrefab, Vector3.zero, Quaternion.identity, BulletPoolTransform);
            obj.SetActive(false);
            _bulletPool.Add(obj);
        }
    }

    private GameObject GetFromBulletPool()
    {
        foreach(GameObject i in _bulletPool)
        {
            if (!i.activeSelf)
                return i;
        }

        GameObject obj = Instantiate(BulletPrefab, Vector3.zero, Quaternion.identity, BulletPoolTransform);
        obj.SetActive(false);
        _bulletPool.Add(obj);
        return obj;
    }
}
