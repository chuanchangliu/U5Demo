using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LuaFramework {
    public class LuaBehaviour : MonoBehaviour
    {
 
        private List<LuaFunction> luaFunctions = new List<LuaFunction>();

        protected void Awake()
        {
            LuaTable table = LuaClient.GetMainState().GetTable(name);
            if (table == null)
            {
                throw new LuaException(string.Format("Lua table {0} not exists", name));
            }

            Util.CallMethod(name, "Awake", gameObject, this);
        }

        protected void Start() {
            Util.CallMethod(name, "Start");
        }

        protected void OnDisable()
        {
            Util.CallMethod(name, "OnDisable");
        }

        protected void OnEnable()
        {
            Util.CallMethod(name, "OnEnable");
        }

        protected void OnDestroy()
        {
            Util.CallMethod(name, "OnDestroy");
            ClearClick();
            //Util.ClearMemory();
        }


        protected void ClearClick()
        {
            foreach (var de in luaFunctions) { de.Dispose(); }
            luaFunctions.Clear();
        }

        public void AddEventListener(GameObject go, LuaFunction luafunc, string trigger)
        {
            if (go == null || luafunc == null) return;

            if (trigger.Equals("click"))
                UIEventListener.Get(go).onClick = (o) => { luafunc.Call(o); };

            else if (trigger.Equals("press"))
                UIEventListener.Get(go).onPress = (o, isPress) => { luafunc.Call(o, isPress); };

            else if (trigger.Equals("dragStart"))
                UIEventListener.Get(go).onDragStart = (o) => { luafunc.Call(o); };

            else if (trigger.Equals("drag"))
                UIEventListener.Get(go).onDrag = (o, delta) => { luafunc.Call(o, delta); };

            else if (trigger.Equals("dragEnd"))
                UIEventListener.Get(go).onDragEnd = (o) => { luafunc.Call(o); };

            else if (trigger.Equals("drop"))
                UIEventListener.Get(go).onDrop = (o, target) => { luafunc.Call(o, target); };

            else if (trigger.Equals("doubleclick"))
                UIEventListener.Get(go).onDoubleClick = (o) => { luafunc.Call(o); };

            luaFunctions.Add(luafunc);
        }
    }
}