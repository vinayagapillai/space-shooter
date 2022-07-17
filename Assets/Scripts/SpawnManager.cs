using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _enemyPool;

    private void Start()
    {
        GameObject obj = new GameObject("EnemyPool");
        _enemyPool = obj.GetComponent<Transform>();
        InstantiateEnemies();
        StartCoroutine(SpawnEnemies());
    }

    public void InstantiateEnemies()
    {
        for (int i = 0; i < GameManager.Instance.TotalNoOfEnemies; i++)
        {
            GameObject obj = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity, _enemyPool);
            obj.SetActive(false);
        }
    }

    private GameObject GetInactiveEnemy()
    {
        foreach (Transform i in _enemyPool)
            if (!i.gameObject.activeSelf)
                return i.gameObject;
        return null;
    }

    IEnumerator SpawnEnemies()
    {
        //yield return new WaitForSeconds(1);
        while (_enemyPool.childCount > 0)
        {
            Vector3 pos = new Vector3(10, Random.Range(GameManager.Instance.ScreenMinY, GameManager.Instance.ScreenMaxY), 0);
            GameObject obj = GetInactiveEnemy();
            if (obj != null)
            {
                obj.SetActive(true);
                obj.transform.position = pos;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }

}
