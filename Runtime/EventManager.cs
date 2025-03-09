using System.Collections.Generic;
using UnityEngine.Events;
using Noname.OneUp.Packages.Singleton;
using UnityEngine;

namespace Noname.OneUp.Packages.EventManager
{
    public class EventManager : Singleton<EventManager>
    {
        private static Dictionary<string, UnityEvent<object>> eventDictionary =
            new Dictionary<string, UnityEvent<object>>();

        public void RegisterGlobalEvent(string eventName, UnityAction<object> listener)
        {
            Debug.Log(string.Format("EventManager RegisterGlobalEvent - Event Name Is: {0}", eventName));
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
            Debug.Log(string.Format("EventManager RemoveGlobalEvent - Event Name Is: {0}", eventName));
            UnityEvent<object> currentEvent = null;
            if (eventDictionary.TryGetValue(eventName, out currentEvent))
            {
                currentEvent.RemoveListener(listener);
            }
        }

        public void SendGlobalEvent(string eventName, object value)
        {
            Debug.Log(string.Format("EventManager SendGlobalEvent - Event Name Is: {0} - Event Data Is: {1}", eventName,
                JsonUtility.ToJson(value)));
            UnityEvent<object> currentEvent = null;
            if (eventDictionary.TryGetValue(eventName, out currentEvent))
            {
                currentEvent.Invoke(value);
            }
        }
    }
}