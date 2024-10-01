using Exiled.API.Features;
using MEC;
using RueI.Displays;
using RueI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.HintAPI
{
    public static class RueIHints
    {
        /// <summary>
        /// 显示全局Hint但是不覆盖
        /// </summary>
        /// <param name="time">时长</param>
        /// <param name="pos">坐标(Y)</param>
        /// <param name="message">信息</param>
        public static void MapRueIHint(this HintPox mapPox, float pos, string message, float time)
        {
            foreach (var p in Player.List.Where(x => x != null))
            {
                p.RueIHint(time, pos, $"<align={mapPox}>{message}</align>");
            }
        }

        /// <summary>
        /// 显示Hint但是不覆盖
        /// </summary>
        /// <param name="player">目标</param>
        /// <param name="time">时长</param>
        /// <param name="pos">坐标(Y)</param>
        /// <param name="message">信息</param>
        public static void RueIHint(this Player player, float time, float pos, string message)
        {
            if (player.ReferenceHub == null)
            {
                Log.Debug("Player's ReferenceHub is Null! RueIHint");
                return;
            }

            Display display = new Display(player.ReferenceHub);
            SetElement hint = new SetElement(pos, message)
            {
                ZIndex = 3
            };

            lock (display.Elements)
            {
                display.Elements.Add(hint);
                display.Update();
            }

            Timing.CallDelayed(time, () =>
            {
                lock (display.Elements)
                {
                    if (display.Elements.Contains(hint))
                    {
                        display.Elements.Remove(hint);
                        display.Update();
                    }
                }
            });
        }
        public static int hintCounter = 0; // 新增计数器
        /// <summary>
        /// 显示Hint但是覆盖
        /// </summary>
        /// <param name="player">目标</param>
        /// <param name="time">时间</param>
        /// <param name="pos">坐标</param>
        /// <param name="message">信息</param>
        /// <param name="display">显示List</param>
        public static void Hint(this Player player, float time, float pos, string message)
        {
            Display display = new Display(player.ReferenceHub);
            if (player.ReferenceHub == null)
            {
                Log.Debug("Player's ReferenceHub is Null! RueIHint");
                return;
            }

            if (display == null)
            {
                display = new Display(player.ReferenceHub);
            }

            lock (display.Elements)
            {
                if (hintCounter > 1)
                {
                    display.Elements.RemoveAt(0);
                    hintCounter--;
                }

                SetElement hint = new SetElement(pos, message)
                {
                    ZIndex = 3
                };

                display.Elements.Add(hint);
                display.Update();
                hintCounter++;

                // 延迟删除提示信息
                Timing.CallDelayed(time, () =>
                {
                    lock (display.Elements)
                    {
                        if (display.Elements.Contains(hint))
                        {
                            display.Elements.Remove(hint);
                            display.Update();
                            hintCounter--;
                        }
                    }
                });
            }
        }
    }
}
