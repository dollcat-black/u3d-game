
local updateCount = 0
local player = mainScene.transform:Find('Player')
local mainCamera = Camera.main
player = utils.GameObject:Init(player)
player:SetParent(mainScene)
player:AddComponent(typeof(LuaMonoMgr),true)
local builtin_standard_material = Material(Shader.Find("Standard"))
builtin_standard_material.color = Color(0.5,0.1,0.1)
player:GetComponent(typeof(Renderer)).material = builtin_standard_material

local moveSpeed = player:SetProperties('moveSpeed',80)
local moveSpeedRate = player:SetProperties('moveSpeedRate',0.001)
local jumpRate = player:SetProperties('jumpRate',0.1)
local jumpForce = player:SetProperties('jumpForce',60)

local playerRb = player:GetComponent(typeof(Rigidbody))

player:AddOrRemoveListener(function()
    print(player.target.name..' start.')
end,E_LifeFun_Type.Start)

local direcVctr = Vector3.zero
function player:MoveByAxis(isInFixedUpdate) --w、a、s、d前后左右移动
    isInFixedUpdate = isInFixedUpdate or false
    local isHorDown = self:GetProperties('isHorDown')
    local isVerDown = self:GetProperties('isVerDown')
    if isInFixedUpdate then
        local isGrounded = self:GetProperties('isGrounded')
        if isHorDown or isVerDown then
            if isGrounded then
                self.transform.position = self.transform.position + direcVctr.normalized * moveSpeed * moveSpeedRate
            else
                self.transform.position = Vector3.Lerp(self.transform.position,self.transform.position + direcVctr.normalized * moveSpeed * moveSpeedRate * 0.7,0.5) --跳跃时水平移动速度削弱
            end
        end
        direcVctr = Vector3.zero
        return
    end
    local axisHor = Input.GetAxis('Horizontal')
    local axisVer = Input.GetAxis('Vertical')
    local isBothHorDown = self:GetProperties('isBothHorDown')
    local isBothVerDown = self:GetProperties('isBothVerDown')
    if Input.GetButtonDown('Horizontal') then
        if isHorDown then --已经按下了至少一个
            -- if axisHor < 0 then --已经按下的是left 当前按下的则是right
            -- else --相反
            -- end
            isBothHorDown = self:SetProperties('isBothHorDown',true)
        end
        isHorDown = self:SetProperties('isHorDown',true)
    end
    if Input.GetButtonUp('Horizontal') then
        if isBothHorDown then
            isBothHorDown = self:SetProperties('isBothHorDown',false)
        else
            isHorDown = self:SetProperties('isHorDown',false)
        end
    end
    if isHorDown then
        if not isBothHorDown then
            if axisHor < 0 then --左
                direcVctr = direcVctr + Vector3.left
            elseif axisHor > 0 then --右
                direcVctr = direcVctr + Vector3.right
            end
        end 
    end
    if Input.GetButtonDown('Vertical') then
        if isVerDown then --已经按下了至少一个
            isBothVerDown = self:SetProperties('isBothVerDown',true)
        end
        isVerDown = self:SetProperties('isVerDown',true)
    end
    if Input.GetButtonUp('Vertical') then
        if isBothVerDown then
            isBothVerDown = self:SetProperties('isBothVerDown',false)
        else
            isVerDown = self:SetProperties('isVerDown',false)
        end
    end
    if isVerDown then
        if not isBothVerDown then
            if axisVer < 0 then --前
                direcVctr = direcVctr + Vector3.back
            elseif axisVer > 0 then --后
                direcVctr = direcVctr + Vector3.forward
            end
        end
    end
end

local lastVelocity = 0
function player:Jump() --跳跃
    local jump = Input.GetAxis('Jump')
    local isGrounded = self:GetProperties('isGrounded')
    local currentVelocity = playerRb.velocity.y
    local acceleration = (currentVelocity - lastVelocity) / Time.fixedDeltaTime
    lastVelocity = currentVelocity
    local absAcc = math.abs(acceleration)
    if absAcc > 1 then
        isGrounded = self:SetProperties('isGrounded',false)
    else
        isGrounded = self:SetProperties('isGrounded',true)
    end
    if isGrounded then
        playerRb.velocity.y = 0
    end
    if jump > 0 and isGrounded then
        playerRb:AddForce(Vector3.up * jumpForce * jumpRate,ForceMode.VelocityChange)
        isGrounded = self:SetProperties('isGrounded',false)
    end
end

local mainCameraOffsetWithPlayer = mainCamera.transform.position - player.target.transform.position
function player:CameraWith() --镜头跟随
    mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,player.target.transform.position + mainCameraOffsetWithPlayer,0.9)
end

function player:Update()
    if updateCount % 300 == 0 then --帧计数器
        updateCount = 0
    end
    updateCount = updateCount + 1
    self:MoveByAxis()
end
player:AddOrRemoveListener(function()
    player:Update()
end,E_LifeFun_Type.Update)

function player:FixedUpdate()
    self:MoveByAxis(true)
    self:Jump()
end
player:AddOrRemoveListener(function()
    player:FixedUpdate()
end,E_LifeFun_Type.FixedUpdate)

function player:LateUpdate()
    self:CameraWith()
end
player:AddOrRemoveListener(function()
    player:LateUpdate()
end,E_LifeFun_Type.LateUpdate)

