using System;

public class EventController
{
    public Action baseAction;

    public void AddListener(Action listener) => baseAction += listener;

    public void RemoveListener(Action listener) => baseAction -= listener;

    public void InvokeEvent() => baseAction?.Invoke();
}