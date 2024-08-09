-- package.cpath = package.cpath .. ';C:/Users/Digs/AppData/Roaming/JetBrains/Rider2021.2/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'
-- ___dbg = require('emmy_core')
-- ___dbg.tcpConnect('localhost', 9966)

UnityEngine = CS.UnityEngine
Application = UnityEngine.Application
GameObject = UnityEngine.GameObject
Camera = UnityEngine.Camera
Vector3 = UnityEngine.Vector3
Vector2 = UnityEngine.Vector2
Material = UnityEngine.Material
Rigidbody = UnityEngine.Rigidbody
ForceMode = UnityEngine.ForceMode
Shader = UnityEngine.Shader
Color = UnityEngine.Color
Renderer = UnityEngine.Renderer
Quaternion = UnityEngine.Quaternion
Time = UnityEngine.Time
Input = UnityEngine.Input
PrimitiveType = UnityEngine.PrimitiveType
Destroy = UnityEngine.Destroy
Addressables = CS.UnityEngine.AddressableAssets.Addressables
Coroutine = CS.UnityEngine.Coroutine
ToLua = CS.ToLua

LuaMonoMgr = CS.Common.LuaMonoMgr
E_LifeFun_Type = CS.Common.E_LifeFun_Type
Utils = CS.Common.Utils

Main = CS.NScene01.Main
mainScene = GameObject.Find("MainScene")
csmain = mainScene:GetComponent(typeof(Main))

util = require'util'
utils = require'utils'

prepare = require'prepare'
prepare.OnComplete = function ()
    local res,inst
    res = utils.GetPrefabWithName('Player.prefab')
    inst = GameObject.Instantiate(res)
    inst.transform.parent = mainScene.transform
    inst.name = 'Player'
    res = utils.GetPrefabWithName('小怪物.prefab')
    inst = GameObject.Instantiate(res)
    inst.transform.parent = mainScene.transform
    inst.name = '小怪物'
    require'player'
    require'monster'
end
prepare.LoadRes()