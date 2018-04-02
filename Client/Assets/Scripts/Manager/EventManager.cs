using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : NormSingleton<MessageManager>
{
    public delegate void EventReceiver(params object[] objs);

    public class EventDetail
    {

    }


    public class EventLinked
    {
   
    }


    public void AppendEvent(string eventName, string eventGuid, EventReceiver receiver)
    {

    }

    public void RemoveEvent(string eventName, string eventGuid)
    {
    }
}
