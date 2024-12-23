using BepInEx;
using HarmonyLib;

namespace SafeHome
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.safehome";
        internal const string Name = "Safe Home";
        internal const string Version = "1.2.0.0";
        internal const string ModOptionsGuid = "evilmask.elinplugins.modoptions";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class SafeHome : BaseUnityPlugin
    {
        internal static SafeHome Instance { get; private set; }
        
        private void Start()
        {
            Instance = this;
            
            Harmony.CreateAndPatchAll(type: typeof(Patcher));
        }
        
        public static void Log(object payload)
        {
            Instance.Logger.LogInfo(data: payload);
        }
    }
}