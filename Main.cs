using HarmonyLib;
using BepInEx;
using System.Reflection;

namespace Softlocks_of_Subnautica
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        #region[Declarations]
        private const string
            MODNAME = "softlocksofsubnautica",
            AUTHOR = "yw2theorycrafter",
            GUID = "com.yw2theorycrafter.softlocksofsubnautica",
            VERSION = "1.2.0.0";
        #endregion
        public void Patch()
        {
            Harmony harmony = new Harmony("com.yw2theorycrafter.softlocksofsubnautica");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
#if DEBUG
            Softlocks_of_Subnautica.Logger.Log("Softlocks Of Subnautica loaded.");
#endif
        }
    }
}
