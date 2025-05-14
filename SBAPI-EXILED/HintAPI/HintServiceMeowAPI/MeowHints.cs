using Exiled.API.Features;
using HintServiceMeow.Core.Utilities;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI_EXILED.HintAPI.HintServiceMeowAPI
{
    public static class MeowHints
    {
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
