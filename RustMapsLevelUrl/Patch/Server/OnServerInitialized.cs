using HarmonyLib;
using Steamworks;

namespace RustMapsLevelUrl.Patch.Server
{
    [HarmonyPatch(typeof(ServerMgr), nameof(ServerMgr.OpenConnection))]
    public static class OnServerInitialized
    {
        public static void Postfix()
        {
#if DEBUG
            System.Console.WriteLine("RustMapsLevelUrl | OnServerInitialized");
#endif

            if (string.IsNullOrEmpty(ConVar.Server.levelurl))
            {
                return;
            }

            UnityEngine.Debug.Log($"RustMapsLevelUrl | Set Steamworks world.levelurl to '{ConVar.Server.levelurl}'");
            SteamServer.SetKey("world.levelurl", ConVar.Server.levelurl);
        }
    }
}