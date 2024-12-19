using BepInEx;
using HarmonyLib;

namespace SafeHome
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.safehome";
        internal const string Name = "Safe Home";
        internal const string Version = "1.1.0.0";
        internal const string ModOptionsGuid = "evilmask.elinplugins.modoptions";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class SafeHome : BaseUnityPlugin
    {
        private void Awake()
        {
            Harmony.CreateAndPatchAll(type: typeof(Patcher));
        }
    }
}