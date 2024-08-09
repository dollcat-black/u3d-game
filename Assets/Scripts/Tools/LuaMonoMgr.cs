using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common
{
    public class LuaMonoMgr : MonoBehaviour
    {
        private UnityAction start;
        private UnityAction update;
        private UnityAction fixedUpdate;
        private UnityAction lateUpdate;
        private UnityAction onEnable;
        private UnityAction onDisable;
        private UnityAction onDestroy;

        private void Start()
        {
            if (start != null)
                start();
        }
        
        private void Update()
        {
            if (update != null)
                update();
        }
        
        private void FixedUpdate()
        {
            if (fixedUpdate != null)
                fixedUpdate();
        }
        
        private void LateUpdate()
        {
            if (lateUpdate != null)
                lateUpdate();
        }
        
        private void OnEnable()
        {
            if (onEnable != null)
                onEnable();
        }
        
        private void OnDisable()
        {
            if (onDisable != null)
                onDisable();
        }
        
        private void OnDestroy()
        {
            if (onDestroy != null)
                onDestroy();
            start = null;
            update = null;
            fixedUpdate = null;
            lateUpdate = null;
            onEnable = null;
            onDisable = null;
            onDestroy = null;
        }

        public void AddOrRemoveListener(UnityAction action,E_LifeFun_Type type,bool isAdd = true)
        {
            switch (type)
            {
                case E_LifeFun_Type.Start:
                    if (isAdd)
                        start += action;
                    else
                        start -= action;
                    break;
                case E_LifeFun_Type.Update:
                    if (isAdd)
                        update += action;
                    else
                        update -= action;
                    break;
                case E_LifeFun_Type.LateUpdate:
                    if (isAdd)
                        lateUpdate += action;
                    else
                        lateUpdate -= action;
                    break;
                case E_LifeFun_Type.FixedUpdate:
                    if (isAdd)
                        fixedUpdate += action;
                    else
                        fixedUpdate -= action;
                    break;
                case E_LifeFun_Type.OnEnable:
                    if (isAdd)
                        onEnable += action;
                    else
                        onEnable -= action;
                    break;
                case E_LifeFun_Type.OnDisable:
                    if (isAdd)
                        onDisable += action;
                    else
                        onDisable -= action;
                    break;
                case E_LifeFun_Type.OnDestroy:
                    if (isAdd)
                        onDestroy += action;
                    else
                        onDestroy -= action;
                    break;
            }
        }
    }

    public enum E_LifeFun_Type
    {
        Start,
        Update,
        LateUpdate,
        FixedUpdate,
        OnEnable,
        OnDisable,
        OnDestroy
    }
}
