using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private Transform _transform;
    private GameObject _currentEnemy;

    private void Start()
    {
        _transform = transform;
        
        _currentEnemy = Instantiate(EnemyPrefab, _transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (_currentEnemy == null)
            _currentEnemy = Instantiate(EnemyPrefab, _transform.position, Quaternion.identity);
    }
}
