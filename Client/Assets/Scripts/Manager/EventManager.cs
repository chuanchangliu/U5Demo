using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : NormSingleton<EventManager>
{
    public delegate void EventAction(params object[] objs);

    public class EventStatus
    {
        public string guid;
        public bool active;
        public EventAction action;

        public EventStatus(string guid, EventAction action)
        {
            active = true;
            this.guid = guid;
            this.action = action;
        }

    }

    public class EventStation
    {
        List<EventStatus> eventList = new List<EventStatus>();
        public void Dispatch(object []objs)
        {
            foreach(EventStatus status in eventList)
            {
                if(status.active && status.action != null)
                {
                    try
                    {
                        status.action(objs);
                    }
                    catch(System.Exception exception)
                    {
                        Debug.LogError("event handle error: "+ status.guid);
                        Debug.LogError(exception);
                    }
                }
            }
        }

        public void AppendMember(string guid, EventAction action)
        {
            bool exist = false;
            foreach(EventStatus status in eventList)
            {
                if(status.guid == guid)
                {
                    status.action = action;
                    status.active = true;
                    exist = true;
                }

                if(!exist)
                {
                    eventList.Add(new EventStatus(guid, action));
                }
            }
        }

        public void RemoveMember(string guid)
        {
            foreach(EventStatus status in eventList)
            {
                if(status.guid == guid)
                {
                    status.active = false;
                    break;
                }
            }
        }
    }

    private Dictionary<string, EventStation> eventStore = new Dictionary<string, EventStation>();

    public void AppendEvent(string eventName, string eventGuid, EventAction eventAction)
    {
        if (eventAction == null)
        {
            Debug.LogError("the function for "+ eventGuid + " is null, pleas fix it! ");
            return;
        }

        EventStation station = null;
        if (eventStore.ContainsKey(eventName))
        {
            eventStore.TryGetValue(eventName, out station);
            station.AppendMember(eventGuid, eventAction);
        }
        else
        {
            station = new EventStation();
            station.AppendMember(eventGuid, eventAction);
            eventStore.Add(eventName, station);
        }
    }

    public void RemoveEvent(string eventName, string eventGuid)
    {
        EventStation station = null;
        if(eventStore.ContainsKey(eventName))
        {
            eventStore.TryGetValue(eventName, out station);
            station.RemoveMember(eventGuid);
        }
    }

    public void TriggerEvent(string eventName, params object[] objs)
    {
        EventStation station = null;
        if(eventStore.ContainsKey(eventName))
        {
            eventStore.TryGetValue(eventName,out station);
            try
            {
                station.Dispatch(objs);
            }
            catch(System.Exception exception)
            {
                string str = "!!!!!Error: Game event handle error:" + eventName + "objsCount:";
                str += objs.Length.ToString();
                foreach (object o in objs)
                {
                    str += " " + o.ToString();
                }
                Debug.LogError(str);
                Debug.LogError(exception);
            }
        }
    }
}
