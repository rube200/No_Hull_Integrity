using Harmony;
using System;
using System.Reflection;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Subnautica_No_Hull
{
    public class Main
    {
        public static void Initialize()
        {
            HarmonyInstance.Create("Subnautica.Subnautica_No_Hull.mod").PatchAll(Assembly.GetExecutingAssembly());
            DevConsole.disableConsole = false;
            SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(OnSceneLoaded);
            Console.WriteLine("[No Hull] Loaded");
        }

        private static void OnSceneLoaded(Scene Scene, LoadSceneMode mode)
        {
            if (Scene.name == "Aurora")
                GameModeUtils.ActivateCheat(GameModeOption.NoPressure);
        }
    }
}