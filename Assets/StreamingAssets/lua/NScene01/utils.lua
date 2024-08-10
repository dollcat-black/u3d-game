local utils = {}

utils.testRegionEffectiveness = function()
    print(GameObject.Find('MainScene'))
end

utils.GetPrefabWithName = function(prefabName)
    return prepare.GetCachedRes(prefabName)
end

utils.Instantiate = function(object)
    return GameObject.Instantiate(object)
end

utils.Destroy = function(object)
    GameObject.Destroy(object)
end

utils.LoadPrefabAsync = function(path,cbk)
    return Utils.LoadPrefabAsyncA(path,cbk)
end

utils.GameObject = {}
function utils.GameObject:Init(target)
    local __self = self
    local _self = {}
    function _self:Init(target)
        self.target = target
        self.transform = target.transform
    end
    function _self:SetParent(parent,isRoot)
        isRoot = isRoot or false
        if isRoot then
            self.target.transform.parent = parent
        else
            self.target.transform.parent = parent.transform
        end
    end
    function _self:SetName(name)
        self.target.name = name
    end
    function _self:GetComponent(component)
        return self.target.gameObject:GetComponent(component)
    end
    function _self:AddComponent(component,isLMM)
        isLMM = isLMM or false
        if isLMM then
            self.LuaMonoMgr = self.target.gameObject:AddComponent(component)
        else
            self.target.gameObject:AddComponent(component)
        end
    end
    function _self:AddOrRemoveListener(listener,type)
        if self.LuaMonoMgr == nil then
            return
        end
        self.LuaMonoMgr:AddOrRemoveListener(listener,type)
    end
    function _self:transform()
        return self.target.transform
    end
    function _self:Destroy(object)
        Destroy(object)
    end
    function _self:SetProperties(key,value)
        self[key] = value
        return self[key]
    end
    function _self:GetProperties(key)
        return self[key]
    end
    function _self:removeProperties(key)
        self[key] = nil
    end
    _self:Init(target)
    return _self
end

--计算两点在xz平面投影距离
utils.calcDistanceXZ = function(posA,posB)
    local posA2D = Vector2(posA.x, posA.z)
    local posB2D = Vector2(posB.x, posB.z)
    return Vector2.Distance(posA2D, posB2D)
end

return utils