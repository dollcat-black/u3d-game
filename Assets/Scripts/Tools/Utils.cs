using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using XLua;

namespace Common
{
    public class Utils : MonoBehaviour
    {
        private Utils(){}
        private static readonly Lazy<Utils> _lazy = new Lazy<Utils>(()=>new Utils());
        public static Utils Instance => _lazy.Value;

        private static Dictionary<string, GameObject> loadCache = new Dictionary<string, GameObject>();

        public void LoadPrefabA(string address, LuaFunction callback)
        {
            StartCoroutine(LoadPrefabAsync(address, callback));
        }
        private IEnumerator LoadPrefabAsync(string address, LuaFunction callback)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(address);
            yield return handle;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject prefab = handle.Result;
                callback.Call(prefab);
            }
            else
            {
                Debug.LogError($"Failed to load prefab at address: {address}");
                callback.Call(null);
            }
            Addressables.Release(handle); // 释放资源
        }
        
        public delegate void LoadPrefabAsyncCallbackDelegate(string resName,GameObject gameObject);
        public static async Task<GameObject> LoadPrefabAsyncA(string address,LoadPrefabAsyncCallbackDelegate callbackDelegate)
        {
            if (address == null || address.Equals(""))
            {
                return null;
            }
            string addrMd5 = MD5Encrypt(Encoding.UTF8.GetBytes(address));
            if (loadCache.ContainsKey(addrMd5))
                return loadCache[addrMd5];
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(address);
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log(string.Format("Load '{0}' Success! Hash: {1}",address,addrMd5));
                GameObject prefab = handle.Result;
                loadCache.Add(addrMd5,prefab);
                Addressables.Release(handle);
                callbackDelegate(address,prefab);
                return prefab;
            }
            else
            {
                Debug.LogError($"Failed to load prefab at address: {address}");
                callbackDelegate(address,null);
                return null;
            }
        }

        public static GameObject getGameObjectFromLoadCache(string addrMd5)
        {
            if (loadCache.ContainsKey(addrMd5))
                return loadCache[addrMd5];
            Debug.LogError("GameObject is non-exists!");
            return null;
        }
        
        public static GameObject setGameObjectFromLoadCache(string addrMd5,GameObject gameObject)
        {
            if (loadCache.ContainsKey(addrMd5))
            {
                Debug.LogWarning("Cache Object is exists! It will be overrided!");
                loadCache[addrMd5] = gameObject;
            }
            else
            {
                loadCache.Add(addrMd5,gameObject);
            }
            return loadCache[addrMd5];
        }

        public static GameObject removeGameObjectFromLoadCache(string addrMd5)
        {
            if (loadCache.ContainsKey(addrMd5))
            {
                GameObject gameObject = loadCache[addrMd5];
                loadCache.Remove(addrMd5);
                return gameObject;
            }
            else
            {
                return null;
            }
        }
        
        public static void clearGameObjectFromLoadCache()
        {
            loadCache.Clear();
        }

        public static async Task<int> SimpleAsync(int param)
        {
            int res = await Task.Run(() =>
            {
                Thread.Sleep(6000);
                return param * 9;
            });
            return res;
        }

        #region Common Utils

        #region MD5
        public static string MD5Encrypt(byte[] data)
        {
            MD5 md5 = MD5.Create();
            byte[] targetData = md5.ComputeHash(data);
            StringBuilder byte2String = new StringBuilder();
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String.AppendFormat("{0:x2}", targetData[i]);
            }
            return byte2String.ToString();
        }
        #endregion

        #endregion
    }
}
