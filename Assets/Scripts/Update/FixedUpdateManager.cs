using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateManager : MonoBehaviour
{
    private static List<IFixedUpdateObserver> _observer = new List<IFixedUpdateObserver>();
    private static List<IFixedUpdateObserver> _pendingObserver = new List<IFixedUpdateObserver>();
    private static int _currentIndex;

    private void FixedUpdate()
    {
        for(_currentIndex = _observer.Count - 1; _currentIndex >= 0; _currentIndex--)
        {
            _observer[_currentIndex].OnFixedUpdate();
        }
        _observer.AddRange(_pendingObserver);
        _pendingObserver.Clear();
    }

    public static void RegisterObserver(IFixedUpdateObserver observer)
    {
        _pendingObserver.Add(observer);
    }

    public static void UnRegisterObserver(IFixedUpdateObserver observer)
    {
        _observer.Remove(observer);
        _currentIndex--;
    }
}
