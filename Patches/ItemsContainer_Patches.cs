using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;

namespace Softlocks_of_Subnautica.Patches
{
    [HarmonyPatch]
    public class ItemsContainer_Patches
    {

        [HarmonyPatch(typeof(ItemsContainer), nameof(ItemsContainer.UnsafeAdd), new Type[] { typeof(InventoryItem) })]
#pragma warning disable IDE0051 // Remove unused private members
        static void Postfix(ItemsContainer __instance, InventoryItem __0)
        {
#if DEBUG
            Logger.Log("UnsafeAdd " + __instance.ToString() + " with " + __0.item.GetTechName() + " into " + __0.container.label);
#endif
            string techname = __0.item.GetTechName();
            string label = __0.container.label;

            /*
             * Not patching orange because the area you pick it up you can't bring the prawn suit into
             */
            if ("PrecursorKey_Blue".Equals(techname))
            {
                if (!KnownTech.Contains(TechType.PrecursorKey_Blue))
                {
                    Logger.Log("Unlocking PrecursorKey_Blue");
                    KnownTech.Add(TechType.PrecursorKey_Blue);
                }
            }
            else if ("PrecursorKey_Purple".Equals(techname))
            {
                //Purple doesn't show the "New blueprint synthesized" when picked up, instead it plays a short cutscene with the 
                //tablet and then you just have the tech unlocked. I don't change that behavior, but when this mod kicks
                //in and we detect that you picked it up with the prawn suit it feels right to at least show a little message to 
                //make up for not showing the cutscene.
                if ("StorageLabel".Equals(label) && !KnownTech.Contains(TechType.PrecursorKey_Purple))
                {
                    ErrorMessage.AddMessage($"New blueprint synthesized: Purple tablet");
                    Logger.Log("Unlocking PrecursorKey_Purple");
                    KnownTech.Add(TechType.PrecursorKey_Purple);
                }
            }
            else
            {
#if DEBUG
                Logger.Log("Skipping tech type " + techname);
#endif
            }
        }


    }
}
