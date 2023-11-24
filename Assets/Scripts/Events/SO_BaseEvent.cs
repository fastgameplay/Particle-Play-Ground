using UnityEngine;
using System;

public abstract class SO_BaseEvent : ScriptableObject
{
    public Action Event;
}
public abstract class SO_BaseEvent<T> : ScriptableObject
{
    public Action<T> Event;
}
public abstract class SO_BaseEvent<T,J> : ScriptableObject
{
    public Action<T,J> Event;
}