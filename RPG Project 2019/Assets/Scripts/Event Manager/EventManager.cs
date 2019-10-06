using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    static private EventManager __Current;
    static public EventManager Current

    {
        get
        {
            if (__Current == null)
            {
                __Current = GameObject.FindObjectOfType<EventManager>();
            }

            return __Current;
        }
    }


    delegate void EventListener(EventInfo e);

    Dictionary<System.Type, List<EventListener>> eventListeners;




    // Use this for initialization
    void Start()
    {

    }

    public void RegisterListener<T>(System.Action<T> listener) where T : EventInfo
    {
        System.Type eventType = typeof(T);


        if (eventListeners == null)
        {
            eventListeners = new Dictionary<System.Type, List<EventListener>>();
        }

        if (eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
        {
            eventListeners[eventType] = new List<EventListener>();
        }

        //wraps a type conversation around the event listener 
        EventListener wrapper = (e) => { listener((T)e); };


        eventListeners[eventType].Add(wrapper);
    }

    public void UnregisterListener<T>(System.Action<T> listener) where T : EventInfo
    {
        // TODO

        Debug.Log(eventListeners.Count);
    }

    public void TriggerEvent(EventInfo eventinfo)
    {


        System.Type trueEventInfoClass = eventinfo.GetType();
        if (eventListeners == null || eventListeners[trueEventInfoClass] == null)
        {
            return;
        }

        foreach (EventListener el in eventListeners[trueEventInfoClass])
        {
            el(eventinfo);
        }
    }
}
