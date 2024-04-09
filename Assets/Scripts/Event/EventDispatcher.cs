using System.Collections.Generic;

namespace Server.Event
{
    public class EventDispatcher : SingleTonBase<EventDispatcher>
    {
        public delegate void EventHandler(IEventParam data);
        private Dictionary<string, EventHandler> eventList = new Dictionary<string, EventHandler>();

        public void AddEventListener(string eventName, EventHandler handler)
        {
            if (eventList.ContainsKey(eventName))
            {
                eventList[eventName] += handler;
            }
            else
            {
                eventList.Add(eventName, handler);
            }
        }

        public void RemoveEventListener(string eventName, EventHandler handler)
        {
            if (eventList.ContainsKey(eventName))
            {
                eventList[eventName] -= handler;
                if (eventList[eventName] == null)
                {
                    eventList.Remove(eventName);
                }
            }
        }
        public void RemoveEventListenerAll(string eventName)
        {
            if (eventList.ContainsKey(eventName))
            {
                eventList.Remove(eventName);
            }
        }

        public bool DispatchEvent(string eventName, IEventParam param = null)
        {
           
            if (eventList.ContainsKey(eventName))
            {
                //UnityEngine.Debug.Log("注册了 ： " + eventName);
                eventList[eventName].Invoke(param);
                return true;
            }
            else
            {
               // UnityEngine.Debug.Log("没注册 ： "+eventName);
                return false;
            }
        }
    }
}
