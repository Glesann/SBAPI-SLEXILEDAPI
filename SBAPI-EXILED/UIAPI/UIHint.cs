using Exiled.API.Features;
using MEC;
using SBAPI.HintAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.UIAPI
{
    public static class UIHint
    {
        public static Dictionary<Player, CoroutineHandle> _playerInfoDisplayerCoroutine = new Dictionary<Player, CoroutineHandle>();
        public static IEnumerator<float> PlayerInfoDisplay(this Player p, string msg)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(1);
                p.RueIHint(1, 0, msg);
            }
        }
        /// <summary>
        /// 添加玩家UI
        /// </summary>
        /// <param name="p">需要添加UI的玩家</param>
        /// <param name="msg">需要添加的UI信息</param>
        public static void RegisterPlayerUI(this Player p, string msg)
        {
            _playerInfoDisplayerCoroutine[p] = Timing.RunCoroutine(p.PlayerInfoDisplay(msg));
        }
        /// <summary>
        /// 删除玩家UI
        /// </summary>
        /// <param name="p">需要删除的玩家</param>
        public static void UnRegisterPlayerUI(this Player p)
        {
            if (_playerInfoDisplayerCoroutine.ContainsKey(p))
            {
                Timing.KillCoroutines(_playerInfoDisplayerCoroutine[p]);
                _playerInfoDisplayerCoroutine.Remove(p);
            }
        }
    }
}
