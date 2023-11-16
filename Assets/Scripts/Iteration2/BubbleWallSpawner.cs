using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Iteration2
{
    public class BubbleWallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _wallPrefabLeft;
        [SerializeField] private GameObject _wallPrefabRight;

        [SerializeField] private Transform _parentLeft;
        [SerializeField] private Transform _parentRight;

        [SerializeField] private float _repeatRate = 6;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnWall), _repeatRate, _repeatRate);
        }

        private void SpawnWall()
        {
            if (Random.Range(0, 2) == 0)
            {
                var wall = Instantiate(_wallPrefabLeft, _parentLeft.transform.position, Quaternion.identity,
                    _parentLeft);

                Destroy(wall, _repeatRate);
            }
            else
            {
                var wall = Instantiate(_wallPrefabRight, _parentRight.transform.position, Quaternion.identity,
                    _parentLeft);

                Destroy(wall, _repeatRate);
            }
        }
    }
}