using HarmonyLib;
using Steamworks;

namespace RustMapsLevelUrl.Patch.Server
{
    [HarmonyPatch(typeof(SteamServer), nameof(SteamServer.GameTags), MethodType.Setter)]
    public static class OnGameTagsUpdated
    {
        public static void Prefix(ref string value)
        {
#if DEBUG
            System.Console.WriteLine("RustMapsLevelUrl | OnGameTagsUpdated");
#endif

            if (value.Contains("rustmaps"))
            {
                return;
            }
            
            value += ",rustmaps";
        }
    }
}