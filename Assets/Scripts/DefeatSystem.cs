using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iteration2;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class DefeatSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDefeat;

    [Button()]
    public async void Defeat(int delay = 200)
    {
        DisableGame();
        await Task.Delay(delay);
        _onDefeat.Invoke();
    }

    public void DisableGame()
    {
        DestroyAllObjectsOfTypes(
            typeof(Trap)
        );

        DestroyAllComponentsOfTypes(
            typeof(BubbleWallSpawner),
            typeof(TargetSpawner),
            typeof(Rigidbody2D),
            typeof(ToEdgeStick),
            typeof(MoveAlongEdge),
            typeof(BubbleWall),
            typeof(Enemy),
            typeof(CanonShoot)
        );
    }

    private void DestroyAllComponentsOfTypes(params Type[] componentTypes)
    {
        Object[] components = FindObjectsOnScene(componentTypes);

        DestroyArrayOf(components);
    }

    private void DestroyAllObjectsOfTypes(params Type[] gameObjectsTypes)
    {
        Object[] gameObjects = FindObjectsOnScene(gameObjectsTypes);

        DestroyArrayOf(gameObjects);
    }

    private void DestroyArrayOf(Object[] components)
    {
        foreach (var component in components)
        {
            Destroy(component);
        }
    }

    private Object[] FindObjectsOnScene(params Type[] types)
    {
        var result = new List<Object>();

        foreach (var type in types)
        {
            Object[] objects = FindObjectsOfType(type);
            result.AddRange(objects);
        }

        return result.ToArray();
    }
}