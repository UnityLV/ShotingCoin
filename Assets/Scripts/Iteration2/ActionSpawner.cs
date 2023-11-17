using System;
using UnityEngine;
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

        private int _firstCounter;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnAction), _repeatRate, _repeatRate);
        }

        private void SpawnAction()
        {
            ActionInGame action = GetActionToSpawn();

            SpawnAction(action);
        }

        private ActionInGame GetActionToSpawn()
        {
            bool isPreferredSelected = _preferredAction != -1;
            if (isPreferredSelected)
            {
                return _actions[_preferredAction];
            }

            bool isNotAllObjectShowed = _firstCounter < _actions.Length;
            if (isNotAllObjectShowed)
            {
                return _actions[_firstCounter++];
            }

            return _actions[Random.Range(0, _actions.Length)];
        }

        private void SpawnAction(ActionInGame action)
        {
            var gameObject = Instantiate(action.Action, action.Parent.transform.position, Quaternion.identity,
                action.Parent);

            Destroy(gameObject, _repeatRate);
        }
    }
}