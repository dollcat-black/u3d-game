using System.IO;
using UnityEngine;
using XLua;

namespace NScene01
{
    public class Main : MonoBehaviour
    {
        LuaEnv luaenv = null;
        
        private string luaDir = getStreamingAssetsPath() + "/lua";
        private string sceneName = "NScene01";
        private string separator = "/";
        public static string getStreamingAssetsPath()
        {
            return Application.streamingAssetsPath;
        }
        public string getStreamingAssetsPathI()
        {
            return Application.streamingAssetsPath;
        }
        
        private byte[] CustomLoader(ref string filepath)
        {
            string path = luaDir + separator + sceneName + separator + filepath + ".lua";
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                Debug.LogError("File is Non-existent!");
                return null;
            }
        }
        
        void Start()
        {
            luaenv = new LuaEnv();
            luaenv.AddLoader(CustomLoader);
            luaenv.DoString("require'main'"); //控制转接Lua逻辑
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
}
