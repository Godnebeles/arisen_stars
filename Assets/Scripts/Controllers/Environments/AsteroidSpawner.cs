using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("ASTEROIDS")]
    [SerializeField] private GameObject[] _hazards;
    [SerializeField] private Vector3 _spawnValues;
    [SerializeField] private int _hazardCount;
    [SerializeField] private float _spawnWait;
    [SerializeField] private float _startWait;
    [SerializeField] private float _wavesWait;

    [SerializeField] private Boundary _boundary;
    
    private void Start()
    {
        StartCoroutine(SpawnWaves());

    
    }
 

    private IEnumerator SpawnWaves()
    {
        if (Screen.width < Screen.height)
        {
            float width = Screen.width;
            float height = Screen.height;
            float x = width / height * 10f;
            _spawnValues.x = x - 0.6f;
        }
        else
        {
            float width = Screen.width;
            float height = Screen.height;
            float x = height / width * 10f;
            _spawnValues.x = x - 1.3f;
        }


        yield return new WaitForSeconds(_startWait); // waiting for start asteroid
        while (true)
        {
            for (int i = 0; i < _hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-_spawnValues.x, _spawnValues.x), _spawnValues.y, _spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazard = _hazards[Random.Range(0, _hazards.Length)];
                EvasiveManeure enemy = Instantiate(hazard, spawnPosition, spawnRotation).GetComponent<EvasiveManeure>();
                if(enemy)
                    enemy.InitBoundary(_boundary);
                yield return new WaitForSeconds(Random.Range(0.5f, _spawnWait));
            }
            yield return new WaitForSeconds(_wavesWait);

        }
    }
}
