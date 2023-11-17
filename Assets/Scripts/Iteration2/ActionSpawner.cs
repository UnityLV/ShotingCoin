using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Iteration2
{
    [Serializable]
    public class ActionInGame
    {
        public GameObject Action;
        public Transform Parent;
    }

    public class ActionSpawner : MonoBehaviour
    {
        [SerializeField] private ActionInGame[] _actions;

        [SerializeField] private float _repeatRate = 5;

        [SerializeField] private int _preferredAction = -1;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnAction), _repeatRate, _repeatRate);
        }

        private void SpawnAction()
        {
            ActionInGame action = _actions[Random.Range(0, _actions.Length)];

            if (_preferredAction != -1)
            {
                action = _actions[_preferredAction];
            }

            SpawnAction(action);
        }

        private void SpawnAction(ActionInGame action)
        {
            var gameObject = Instantiate(action.Action, action.Parent.transform.position, Quaternion.identity,
                action.Parent);

            Destroy(gameObject, _repeatRate);
        }
    }
}