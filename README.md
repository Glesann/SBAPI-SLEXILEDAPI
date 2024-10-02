# 一个也很适合中国宝宝体质的EXILED框架API 
 
## 食用方法
### RuelHint(基于RueI与JBAPI)
首先，你需要先在你服务器内安装[Ruel](https://github.com/Ruemena/RueI)

SBAPI提供了两种Hint，RueIHint与MapRueIHint

· ***RueIHint***  

``` csharp
using SBAPI.HintAPI;

player.RueIHint(400, "Hello World", 10);
```
特点：把Hint钉死在这个位置  
参数：位置，文本，时间

· ***MapRueIHint***
``` csharp
using SBAPI.Hint;

HintPox.right.MapRueIHint(800, "Hello World"， 800);
//其中枚举成员right，center，left为hint的显示位置
```
特点：  把Hint钉死在这个位置的全地图版本
参数：位置，文本，时间

### 自定义UI

API提供了一个添加玩家UI以及一个删除玩家UI的方法(不过你完全可以自己写)

· ***RegisterPlayerUI***  

``` csharp
using SBAPI.UIAPI;

public void OnPlayerVerified(VerifiedEventArgs ev)
{
    if (ev.Player != null)
    {
        ev.Player.RegisterPlayerUI($"玩家：{ev.Player.Nickname} | 欢迎来到xxxxxx服务器 | QQ群：1145141919810");
    }
}
```
· ***UnRegisterPlayerUI***  

``` csharp
using SBAPI.UIAPI;

public void OnPlayerLeft(LeftEventArgs ev)
{
    if (ev.Player != null)
    {
        ev.Player.UnRegisterPlayerUI();
    }
}
```
特点：把UI定死在这个屏幕的最下方  
参数：文本

### 消息队列

API还提供了一个增加消息队列组的方法，一个移除消息队列组的方法，一个添加消息到队列组的方法

· ***AddQueue***  

``` csharp
using SBAPI.MessageAPI;

HintPox.right.AddQueue(1, 800);
```
参数：消息队列组ID，行高
· ***RemoveQueue***  

``` csharp
using SBAPI.MessageAPI;

1.RemoveQueueHint();
```
· ***AddQueueHint***  

``` csharp
using SBAPI.MessageAPI;

1.AddQueueHint("第一条消息", 10);
```
参数：消息内容，时间
特点：将消息按照加入顺序显示出来，可以设置多个队列消息组互不干扰  

### 自定义角色死亡广播· ***By Xiuer***  

API还提供了一个自定义角色死亡后的Cassie广播提示
· ***RemoveQueue***  

``` csharp
using SBAPI.RoleCassieAPI;

ev.DamageHandler.CassiePlus("scp 1 1 4 5 1 4", "SCP-114514");
```


参数：Cassie广播内容，Cassie广播显示内容
特点：便于进行插件角色的Cassie配置。如果你需要根据死亡原因设置广播，那么这项功能很适合你  

