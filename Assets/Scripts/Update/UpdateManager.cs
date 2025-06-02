using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private static List<IUpdateObserver> _observer = new List<IUpdateObserver>();
    private static List<IUpdateObserver> _pendingObserver = new List<IUpdateObserver>();
    private static int currentIndex;

    private void Update()
    {
        for (currentIndex = _observer.Count - 1; currentIndex >= 0; currentIndex--)
        {
            _observer[currentIndex].OnUpdate();
        }
        _observer.AddRange(_pendingObserver);
        _pendingObserver.Clear();
    }

    public static void RegisterObserver(IUpdateObserver observer)
    {
        _pendingObserver.Add(observer);
    }

    public static void UnRegisterObserver(IUpdateObserver obsever)
    {
        _observer.Remove(obsever);
        currentIndex--;
    }
}
