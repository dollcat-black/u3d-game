using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class main : MonoBehaviour
{
    LuaEnv luaenv = null;
    
    void Start()
    {
        luaenv = new LuaEnv();
        luaenv.DoString("require'main'");
    }

    void Update()
    {
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }
    
    void Destroy()
    {
        if (luaenv != null)
        {
            luaenv.Dispose();
        }
    }
}
