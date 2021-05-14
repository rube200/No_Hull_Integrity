using System;
using System.Reflection;
using HarmonyLib;

namespace RG.Subnautica_No_Hull
{
    public class Main
    {
        public static readonly MethodInfo RequiresReinforcementsMethod =
            typeof(GameModeUtils).GetMethod(nameof(GameModeUtils.RequiresReinforcements),
                BindingFlags.Static | BindingFlags.Public);

        public static readonly HarmonyMethod ReinforcementsCancelMethod =
            new HarmonyMethod(typeof(Main).GetMethod(nameof(ReinforcementsCancel),
                BindingFlags.Static | BindingFlags.NonPublic));

        public static void Initialize()
        {
            var harmony = new Harmony("RG.Subnautica_No_Hull");
            harmony.Patch(RequiresReinforcementsMethod, ReinforcementsCancelMethod);
            Console.WriteLine("[No Hull] Loaded");
        }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once RedundantAssignment
        private static bool ReinforcementsCancel(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}