preLoad = {}
preLoad.loadCnt = 1
preLoad.loadCompleteCnt = 0
preLoad.loadCache = {}
preLoad.resList = {
    'NScene01:Assets/Prefabs/Player.prefab',
    'NScene01:Assets/Prefabs/小怪物.prefab',
}

preLoad.LoadRes = function ()
    function loadedCbk(resName,prefab)
        local lastSlash = resName:find("/[^/]*$")
        if lastSlash then
            resName = resName:sub(lastSlash + 1)
        end
        
        if prefab == nil then
            print('res loaded fail')
        end
        if preLoad.loadCache[resName] then
            print('res loaded before, it will be override!')
        end
        preLoad.loadCompleteCnt = preLoad.loadCompleteCnt + 1
        preLoad.loadCache[resName] = prefab
        if preLoad.loadCnt == preLoad.loadCompleteCnt then
            preLoad.isLoadComplete = true
            if preLoad.OnComplete then
                preLoad.OnComplete()
            end
        end
    end
    for index, value in ipairs(preLoad.resList) do
        preLoad.loadCnt = preLoad.loadCnt + 1
        utils.LoadPrefabAsync(value,loadedCbk)
    end
    preLoad.loadCnt = preLoad.loadCnt - 1
end
preLoad.GetCachedRes = function (resName)
    local res = preLoad.loadCache[resName]
    if res then
        return res
    end
    print('res is non-exists!')
    return nil
end

return preLoad