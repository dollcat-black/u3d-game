
local player = mainScene.transform:Find('Player')
local monster = mainScene.transform:Find('小怪物')

player = utils.GameObject:Init(player)
player:SetParent(mainScene)
monster = utils.GameObject:Init(monster)
monster:AddComponent(typeof(LuaMonoMgr),true)
local builtin_standard_material = Material(Shader.Find("Standard"))
builtin_standard_material.color = Color(0.1,0.5,0.5)
monster:GetComponent(typeof(Renderer)).material = builtin_standard_material

function monster.Start()
    print(monster.target.name..' start.')
end
monster:AddOrRemoveListener(monster.Start,E_LifeFun_Type.Start)

local rSpeed = 100
local x = 0
local radius = 5
function monster:SRotateAround()
    local selfPos = self.target.transform.position
    local playerPos = player.target.transform.position
    self.target.transform:RotateAround(playerPos,Vector3.up,2*rSpeed*Time.deltaTime)
    selfPos = self.target.transform.position --更新selfPos
    local direction = (selfPos - playerPos).normalized
    local currentY = selfPos.y
    self.target.transform.position = playerPos + direction * radius
    selfPos = self.target.transform.position  --更新selfPos
    self.target.transform.position = Vector3(selfPos.x, currentY, selfPos.z)
end

function monster.Update()
    monster:SRotateAround()
end
monster:AddOrRemoveListener(monster.Update,E_LifeFun_Type.Update)