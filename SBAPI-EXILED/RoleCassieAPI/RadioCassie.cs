using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Respawning.NamingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.RoleCassieAPI
{
    public static class RadioCassie
    {
        /// <summary>
        /// 广播插件角色SCP死亡-By Xiuer_Talent~
        /// </summary>
        /// <param name="cassiename">需要广播读取的名</param>
        /// <param name="translatedname">翻译名</param>
        /// <param name="damageHandler">伤害</param>
        /// <param name="isSpecialHuman">是否广播被SCP击杀</param>
        /// <param name="isNoisy">是否开启噪音</param>
        /// <param name="isTranslate">是否翻译</param>
        ///  广播插件角色SCP死亡-By Xiuer_Talent~
        public static void CassiePlus(this DamageHandler damageHandler, string cassiename, string translatedname,  bool isSpecialHuman = false, bool isNoisy = true, bool isTranslate = true)
        {
            if (!isSpecialHuman)
            {
                var cassieenglish_ = GetCassie(damageHandler, true);
                var cassietranslation_ = GetCassieTranslation(damageHandler, true);
                if (!isNoisy)
                {
                    if (isTranslate)
                        Cassie.MessageTranslated($"{cassiename} {cassieenglish_}", $"{translatedname} {cassietranslation_}", false, false);
                    else
                        Cassie.Message($"{cassiename} {cassieenglish_}", false, false);
                }
                else
                {
                    if (isTranslate)
                        Cassie.MessageTranslated($"{cassiename} {cassieenglish_}", $"{translatedname} {cassietranslation_}");
                    else
                        Cassie.Message($"{cassiename} {cassieenglish_}");
                }
            }
            else
            {
                var cassieenglish = GetCassie(damageHandler);
                var cassietranslation = GetCassieTranslation(damageHandler);
                if (!isNoisy)
                {
                    if (isTranslate)
                        Cassie.MessageTranslated($"{cassiename} {cassieenglish}", $"{translatedname} {cassietranslation}", false, false);
                    else
                        Cassie.Message($"{cassiename} {cassieenglish}", false, false);
                }
                else
                {
                    if (isTranslate)
                        Cassie.MessageTranslated($"{cassiename} {cassieenglish}", $"{translatedname} {cassietranslation}");
                    else
                        Cassie.Message($"{cassiename} {cassieenglish}");
                }
            }
        }
        private static string GetCassieTranslation(DamageHandler damageHandler, bool specialhuman = false)
        {
            if (!specialhuman)
            {
                if (damageHandler == null)
                    return "已被成功消灭，死亡原因不明。";
                if (damageHandler.Type == DamageType.Tesla)
                    return "已被自动安保系统成功消灭。";
                else if (damageHandler.Type == DamageType.Decontamination)
                    return "已被轻收容净化系统清除。";
                else if (damageHandler.Type == DamageType.Warhead)
                    return "已被Alpha核弹头成功消灭。";
                else if (damageHandler.Attacker != null)
                {
                    if (damageHandler.Attacker.IsCHI)
                        return "已被混沌分裂者重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.ClassD)
                        return "已被D级人员重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.Scientists)
                        return "已被科学家重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.FoundationForces)
                    {
                        return $"已被{damageHandler.Attacker.UnitName}重新收容";
                    }
                    else
                        return "已被成功消灭，死亡原因不明。";
                }
                else
                    return "已被成功消灭，死亡原因不明。";
            }
            else
            {
                if (damageHandler == null)
                    return "已被成功消灭，死亡原因不明。";
                if (damageHandler.Type == DamageType.Tesla)
                    return "已被自动安保系统成功消灭。";
                else if (damageHandler.Type == DamageType.Decontamination)
                    return "已被轻收容净化系统清除。";
                else if (damageHandler.Type == DamageType.Warhead)
                    return "已被Alpha核弹头成功消灭。";
                else if (damageHandler.Attacker != null)
                {
                    if (damageHandler.Attacker.IsCHI)
                        return "已被混沌分裂者重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.ClassD)
                        return "已被D级人员重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.Scientists)
                        return "已被科学家重新收容。";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.FoundationForces)
                        return $"已被{damageHandler.Attacker.UnitName}重新收容";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp049)
                        return "已被SCP-049成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp0492)
                        return "已被SCP-049-2成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp096)
                        return "已被SCP-096成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp106)
                        return "已被SCP-106成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp173)
                        return "已被SCP-173成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp3114)
                        return "已被SCP-3114成功消灭。";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp939)
                        return "已被SCP-939成功消灭。";
                    else
                        return "已被成功消灭，死亡原因不明。";
                }
                else
                    return "已被成功消灭，死亡原因不明。";
            }
        }
        private static string GetCassie(DamageHandler damageHandler, bool specialhuman = false)
        {
            if (!specialhuman)
            {
                if (damageHandler == null)
                    return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
                if (damageHandler.Type == DamageType.Tesla)
                    return "SUCCESSFULLY TERMINATED BY AUTOMATIC SECURITY SYSTEM";
                else if (damageHandler.Type == DamageType.Decontamination)
                    return "LOST IN DECONTAMINATION SEQUENCE";
                else if (damageHandler.Type == DamageType.Warhead)
                    return "SUCCESSFULLY TERMINATED BY ALPHA WARHEAD";
                else if (damageHandler.Attacker != null)
                {
                    if (damageHandler.Attacker.IsCHI)
                        return "CONTAINEDSUCCESSFULLY BY CHAOSINSURGENCY";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.ClassD)
                        return "CONTAINEDSUCCESSFULLY BY CLASSD PERSONNEL";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.Scientists)
                        return "CONTAINEDSUCCESSFULLY BY SCIENCE PERSONNEL";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.FoundationForces)
                    {
                        UnitNamingRule unitNamingRule;
                        UnitNamingRule.TryGetNamingRule(Respawning.SpawnableTeamType.NineTailedFox, out unitNamingRule);
                        string cassieUnit = unitNamingRule.GetCassieUnitName(damageHandler.Attacker.UnitName);
                        return $"CONTAINEDSUCCESSFULLY , CONTAINMENTUNIT {cassieUnit}";
                    }
                    else
                        return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
                }
                else
                    return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
            }
            else
            {
                if (damageHandler == null)
                    return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
                if (damageHandler.Type == DamageType.Tesla)
                    return "SUCCESSFULLY TERMINATED BY AUTOMATIC SECURITY SYSTEM";
                else if (damageHandler.Type == DamageType.Decontamination)
                    return "LOST IN DECONTAMINATION SEQUENCE";
                else if (damageHandler.Type == DamageType.Warhead)
                    return "SUCCESSFULLY TERMINATED BY ALPHA WARHEAD";
                else if (damageHandler.Attacker != null)
                {
                    if (damageHandler.Attacker.IsCHI)
                        return "CONTAINEDSUCCESSFULLY BY CHAOSINSURGENCY";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.ClassD)
                        return "CONTAINEDSUCCESSFULLY BY CLASSD PERSONNEL";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.Scientists)
                        return "CONTAINEDSUCCESSFULLY BY SCIENCE PERSONNEL";
                    else if (damageHandler.Attacker.Role.Team == PlayerRoles.Team.FoundationForces)
                    {
                        UnitNamingRule unitNamingRule;
                        UnitNamingRule.TryGetNamingRule(Respawning.SpawnableTeamType.NineTailedFox, out unitNamingRule);
                        string cassieUnit = unitNamingRule.GetCassieUnitName(damageHandler.Attacker.UnitName);
                        return $"CONTAINEDSUCCESSFULLY , CONTAINMENTUNIT {cassieUnit}";
                    }
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp049)
                        return "SUCCESSFULLY TERMINATED BY SCP  0 4 9";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp0492)
                        return "SUCCESSFULLY TERMINATED BY SCP  0 4 9 2";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp096)
                        return "SUCCESSFULLY TERMINATED BY SCP  0 9 6";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp106)
                        return "SUCCESSFULLY TERMINATED BY SCP  1 0 6";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp173)
                        return "SUCCESSFULLY TERMINATED BY SCP  1 7 3";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp3114)
                        return "SUCCESSFULLY TERMINATED BY SCP  3 1 1 4";
                    else if (damageHandler.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp939)
                        return "SUCCESSFULLY TERMINATED BY SCP  9 3 9";
                    else
                        return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
                }
                else
                    return "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
            }
        }
    }
}
