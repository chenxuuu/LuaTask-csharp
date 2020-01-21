# LuaTask-csharp

[![Nuget](https://img.shields.io/nuget/dt/LuaTask?label=nuget%20download)](https://www.nuget.org/packages/LuaTask)

C#下实现Luat Task框架功能，包括定时器、多任务功能，支持`.net core`。

C# with `Luat Task` framework, include timer and multitask, support `.net core`.

接口参考[https://github.com/chenxuuu/llcom/blob/master/LuaApi.md#sys](https://github.com/chenxuuu/llcom/blob/master/LuaApi.md#sys)

移植自[合宙Luat Task架构](http://wiki.openluat.com/doc/luatFramework/)

## example

timer

```lua
print('start',os.time())
sys.timerStart(function()
    print('one second later',os.time())
end,1000)

sys.timerLoopStart(function()
    print('every one second',os.time())
end,1000)
```

---

multitask

```lua
sys.taskInit(function()
    while true do
        print('task1',os.time())
        sys.wait(2000)
    end
end)

sys.taskInit(function()
    while true do
        print('task2',os.time())
        sys.wait(3000)
    end
end)
```

---

C# call back function

```lua
sys.tiggerRegister("test",function(data)
    print("tigger!",data.s,data.n)
end)
```

```csharp
var lua = new LuaTask.LuaEnv();
lua.addTigger("test", new
{
    s = "test string",
    n = 12345
});
```

---

async C#

```lua
sys.async('net45Test','net45Test.Test.test',1,
function(r,data)
print('cb function long',r,data,os.time())
end)

sys.async('net45Test','net45Test.Test.test',nil,
function(r,data)
print('cb function void',r,data,os.time())
end)

sys.async('net45Test','net45Test.Test.test',{123,'text'},
function(r,data)
print('cb function long string',r,data,os.time())
end)

import('System')
local time = TimeSpan(10000000)
sys.async('mscorlib','System.Threading.Thread.Sleep',time,
function(r,data)
print('cb function Thread.Sleep 1 second',r,data,os.time())
end)

print(os.time())
```
