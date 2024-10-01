using Exiled.API.Features;
using MEC;
using SBAPI.HintAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SBAPI.HintAPI.RueIHints;
using static SBAPI.MessageAPI.QueueMessage;

namespace SBAPI.MessageAPI
{
    public static class QueueMessage
    {

        public static Dictionary<int, CoroutineHandle> QueueHintCoroutine = new Dictionary<int, CoroutineHandle>();
        public static Dictionary<int, Queue<string>> QueueHintMsg = new Dictionary<int, Queue<string>>();
        public static Dictionary<string, int> QueueTimer = new Dictionary<string, int>();
        public static int msgCount = 0;
        /// <summary>
        /// 添加一个队列消息在一个位置
        /// </summary>
        /// <param name="id">消息队列组ID</param>
        /// <param name="msg">消息内容</param>
        /// <param name="timer">消息展示时间</param>
        /// <param name="line">消息展示的高度</param>
        /// <param name="hintPox">消息展示的位置(align Tag)，center, right, left</param>
        public static void AddQueueHint(this HintPox hintPox, int id, string msg, int timer, int line)
        {
            msgCount++;
            msg = $"<size=60%>{msg}</size><size=0.01%>{msgCount}</size>";
            QueueHintMsg[id] = new Queue<string>();
            QueueHintMsg[id].Enqueue(msg);
            QueueTimer[msg] = timer;

            QueueHintCoroutine[id] = Timing.RunCoroutine(QueueHint(id, line, hintPox));

        }
        /// <summary>
        /// 移除消息队列组
        /// </summary>
        /// <param name="id">消息队列组</param>
        public static void RemoveQueueHint(this int id)
        {
            if (QueueHintMsg.ContainsKey(id))
            {
                QueueHintMsg.Remove(id);
            }
            if (QueueHintCoroutine.ContainsKey(id))
            {
                Timing.KillCoroutines(QueueHintCoroutine[id]);
            }

        }

        
        public static IEnumerator<float> QueueHint(int id, int line, HintPox hintPox)
        {
            for (; ; )
            {
                yield return Timing.WaitForSeconds(1f);
                try
                {
                    var messagesCopy = new Queue<string>(QueueHintMsg[id]);
                    foreach (string msg in messagesCopy)
                    {
                        line -= 20;
                        int msgTimerrr = QueueTimer[msg];
                        msgTimerrr--;
                        string mesg = msg;
                        QueueTimer[msg] = msgTimerrr;
                        string msg1 = $"<size=60%>[{msgTimerrr}]</size> {mesg}";
                        hintPox.MapRueIHint(1, msg1, line);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }
    }
}
