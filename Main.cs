using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.API;
using System.Reflection;

namespace Softlocks_of_Subnautica
{
    // Your main patching class must have the QModCore attribute (and must be public)
    [QModCore]
    public static class Main
    {
        // Your patching method must have the QModPatch attribute (and must be public)
        [QModPatch]
        public static void Patch()
        {
            // Add your patching code here
            //QModServices.Main.AddCriticalMessage("Softlocks Of Subnautica loaded.");
#if DEBUG
            Logger.Log("Softlocks Of Subnautica loaded.");
#endif
            Harmony harmony = new Harmony("com.yw2theorycrafter.softlocksofsubnautica");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
