using System.Runtime.CompilerServices;
using BepInEx;
using HarmonyLib;

namespace SafeHome;

internal static class ModInfo
{
    internal const string Guid = "omegaplatinum.elin.safehome";
    internal const string Name = "Safe Home";
    internal const string Version = "2.0.0";
}

[BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
internal class SafeHome : BaseUnityPlugin
{
    internal static SafeHome? Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Harmony.CreateAndPatchAll(type: typeof(Patcher), harmonyInstanceId: ModInfo.Guid);
    }

    internal static void LogDebug(object message, [CallerMemberName] string caller = "")
    {
        Instance?.Logger.LogDebug(data: $"[{caller}] {message}");
    }

    internal static void LogInfo(object message)
    {
        Instance?.Logger.LogInfo(data: message);
    }

    internal static void LogError(object message)
    {
        Instance?.Logger.LogError(data: message);
    }
}
