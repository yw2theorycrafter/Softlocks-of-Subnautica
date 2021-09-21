using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;

namespace Softlocks_of_Subnautica.Patches
{
    [HarmonyPatch]
    public class Pickupable_Patches
    {
        [HarmonyPatch(typeof(Pickupable), nameof(Pickupable.SetInventoryItem), new Type[] { typeof(InventoryItem) })]
#pragma warning disable IDE0051 // Remove unused private members
        static void Postfix(Pickupable __instance, ref InventoryItem __0)
        {
#if DEBUG
            Logger.Log("OnPickedUp" + __instance.ToString() + " with " + __0 + " " + __0.item.GetTechName());
#endif
            string techname = __instance.GetTechName();
            if ("PrecursorKey_Blue".Equals(techname))
            {
                Logger.Log("Giving PrecursorKey_Blue");
                KnownTech.Add(TechType.PrecursorKey_Blue);
            } else
            if ("PrecursorKey_Purple".Equals(techname))
            {
                Logger.Log("Giving PrecursorKey_Purple");
                KnownTech.Add(TechType.PrecursorKey_Purple);
            }
            else
            if ("PrecursorKey_Orange".Equals(techname))
            {
                Logger.Log("Giving PrecursorKey_Orange");
                KnownTech.Add(TechType.PrecursorKey_Orange);
            } else
            {
#if DEBUG
                Logger.Log("Skipping tech type " + __instance.GetTechName());
#endif
            }
        }
    }
}
