using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace JPEAK_SV_SaveEverywhere
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class JPEAK_SV_SaveEverywhere : BaseUnityPlugin
    {

        private const string MyGUID = "com.jpb.JPEAK_SV_SaveEverywhere";
        private const string PluginName = "JPEAK_SV_SaveEverywhere";
        private const string VersionString = "1.0.0";

  
        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake()
        {

            // Apply all of our patches
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.CreateAndPatchAll(typeof(JPEAK_SV_SaveEverywhere), null);
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");

            Log = Logger;
        }


        [HarmonyPatch(typeof(GameManager), "CheckPlayerSafe")]
        [HarmonyPostfix]
        static bool PlayerSafe_post(bool ___result)
        {
            return ___result = true;
        }

    }
}
