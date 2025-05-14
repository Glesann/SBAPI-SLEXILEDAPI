using Exiled.API.Features;
using HintServiceMeow.Core.Utilities;
using MEC;
using SBAPI.HintAPI.RueIAPI;
using SBAPI.HintAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI_EXILED.HintAPI.HintServiceMeowAPI
{
    public static class MeowHints
    {
        /// <summary>
        /// 为所有玩家显示Hint（HintServiceMeow）
        /// </summary>
        /// <param name="mapPox">地图显示位置（文本对其方式）</param>
        /// <param name="time">时长</param>
        /// <param name="pos">坐标(Y)</param>
        /// <param name="message">信息</param>
        public static void MapRueIHint(this HintServiceMeow.Core.Enum.HintAlignment mapPox, float pos, string message, float time)
        {
            foreach (var p in Player.List.Where(x => x != null))
            {
                p.MeowHint(time, pos, $"{message}", hintAlignment: mapPox);
            }
        }

        /// <summary>
        /// 为玩家显示Hint（HintServiceMeow）
        /// </summary>
        /// <param name="player">玩家</param>
        /// <param name="time">显示时间</param>
        /// <param name="pos">显示位置(Y)</param>
        /// <param name="message">显示消息</param>
        /// <param name="offset">偏移量(X)</param>
        /// <param name="size">文本大小</param>
        /// <param name="lineHeight">文本额外间距</param>
        /// <param name="hintAlignment">文本对齐方式</param>
        public static void MeowHint(this Player player, float time, float pos, string message, float offset = 0, int size = 30, int lineHeight = 0, HintServiceMeow.Core.Enum.HintAlignment hintAlignment = HintServiceMeow.Core.Enum.HintAlignment.Center)
        {
            if (player.ReferenceHub == null)
            {
                Log.Debug("Player's ReferenceHub is Null! HintServiceMeowAPI");
                return;
            }

            var newPos = 1080 - pos * 1080 / 1000;
            HintServiceMeow.Core.Models.Hints.Hint hint = new HintServiceMeow.Core.Models.Hints.Hint()
            {
                Alignment = hintAlignment,
                YCoordinateAlign = HintServiceMeow.Core.Enum.HintVerticalAlign.Bottom,
                YCoordinate = newPos,
                FontSize = size,
                LineHeight = lineHeight,
                Text = message,
                XCoordinate = offset,
            };
            PlayerDisplay.Get(player.ReferenceHub).AddHint(hint);
            Timing.CallDelayed(time, () =>
            {
                PlayerDisplay.Get(player.ReferenceHub).RemoveHint(hint);
            });
        }
    }
}
