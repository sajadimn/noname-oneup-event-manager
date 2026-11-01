using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    private static Dictionary<string, UnityEvent<object>> eventDictionary =
        new Dictionary<string, UnityEvent<object>>();

    public void RegisterGlobalEvent(string eventName, UnityAction<object> listener)
    {
        Debug.Log($"EventManager RegisterGlobalEvent - Event Name Is: {eventName}");

        UnityEvent<object> currentEvent = null;
        if (eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.AddListener(listener);
        }
        else
        {
            currentEvent = new UnityEvent<object>();
            currentEvent.AddListener(listener);
            eventDictionary.Add(eventName, currentEvent);
        }
    }

    public void RemoveGlobalEvent(string eventName, UnityAction<object> listener)
    {
        Debug.Log($"EventManager RemoveGlobalEvent - Event Name Is: {eventName}");

        UnityEvent<object> currentEvent = null;
        if (eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.RemoveListener(listener);
        }
    }

    public void SendGlobalEvent(string eventName, object value)
    {
        Debug.Log($"EventManager SendGlobalEvent - Event Name Is: {eventName}");

        UnityEvent<object> currentEvent = null;
        if (eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.Invoke(value);
        }
    }
}