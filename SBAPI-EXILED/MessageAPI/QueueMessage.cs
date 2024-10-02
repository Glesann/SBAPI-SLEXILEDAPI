using Exiled.API.Features;
using MEC;
using SBAPI.HintAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SBAPI.HintAPI.RueIHints;

namespace SBAPI.MessageAPI
{
    public static class QueueMessage
    {

        public static Dictionary<int, CoroutineHandle> QueueHintCoroutine = new Dictionary<int, CoroutineHandle>();
        public static Dictionary<int, Queue<string>> QueueHintMsg = new Dictionary<int, Queue<string>>();
        public static Dictionary<int, HintPox> QueueIdPox = new Dictionary<int, HintPox>();
        public static Dictionary<int, int> QueueIdLine = new Dictionary<int, int>();
        public static Dictionary<string, int> QueueTimer = new Dictionary<string, int>();
        public static int msgCount = 0;
        /// <summary>
        /// 添加一个消息到一个消息队列组
        /// </summary>
        /// <param name="id">消息队列组ID</param>
        /// <param name="msg">消息内容</param>
        /// <param name="time">消息展示时间</param>
        /// <param name="line">消息展示的高度</param>
        public static void AddQueueHint(this int id, string msg, int time)
        {
            msgCount++;
            msg = $"<size=60%>{msg}</size><size=0.01%>{msgCount}</size>";
            QueueHintMsg[id].Enqueue(msg);
            QueueTimer[msg] = time;
            QueueHintCoroutine[id] = Timing.RunCoroutine(QueueHint(id, QueueIdLine[id], QueueIdPox[id]));

        }
        /// <summary>
        /// 添加一个消息队列组
        /// </summary>
        /// <param name="hintPox">消息队列组展示的位置(align Tag)，center, right, left</param>
        /// <param name="id">消息队列组的ID</param>
        /// <param name="line">消息队列组第一条消息的高度</param>
        public static void AddQueue(this HintPox hintPox, int id, int line)
        {
            QueueHintMsg[id] = new Queue<string>();
            QueueIdPox[id] = hintPox;
            QueueIdLine[id] = line;
            QueueHintCoroutine[id] = Timing.RunCoroutine(QueueHint(id, line, hintPox));
        }
        /// <summary>
        /// 移除消息队列组
        /// </summary>
        /// <param name="id">消息队列组ID</param>
        public static void RemoveQueue(this int id)
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



        
        private static IEnumerator<float> QueueHint(int id, int line, HintPox hintPox)
        {
            for (; ; )
            {
                yield return Timing.WaitForSeconds(1f);
                try
                {
                    var messagesCopy = new Queue<string>(QueueHintMsg[id]);
                    foreach (string msg in messagesCopy)
                    {
                        int msgTimerrr = QueueTimer[msg];
                        if (msgTimerrr > 0)
                        {
                            line -= 20;
                            msgTimerrr--;
                            string mesg = msg;
                            QueueTimer[msg] = msgTimerrr;
                            string msg1 = $"<size=60%>[{msgTimerrr}]</size> {mesg}";
                            hintPox.MapRueIHint(line, msg1, msgTimerrr);
                        }
                        if (msgTimerrr == 0)
                        {
                            if (QueueHintMsg[id].Contains(msg))
                            {
                                QueueHintMsg[id].Dequeue();
                                if (QueueTimer.ContainsKey(msg))
                                {
                                    QueueTimer.Remove(msg);
                                }
                            }
                        }

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
