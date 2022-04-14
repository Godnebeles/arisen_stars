using System;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private readonly List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();
    public event Action<bool> OnPauseStateChangedEvent;

    public bool IsPaused { get; private set; }

    public void Register(IPauseHandler pauseHandler)
    {
        _pauseHandlers.Add(pauseHandler);
    }

    public void UnRegister(IPauseHandler pauseHandler)
    {
        _pauseHandlers.Remove(pauseHandler);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;

        foreach (IPauseHandler pauseHandler in _pauseHandlers)
        {
            pauseHandler.
                SetPaused(isPaused);
        }

        OnPauseStateChangedEvent?.Invoke(isPaused);
    }
}
