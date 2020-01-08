using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Harmony;
using StardewValley.Menus;

namespace NameGenerator
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            // helper.Content.AssetEditors.Add(new AddDatingPrereq());

            //apply harmony patches
            ApplyPatches();
        }

        public void ApplyPatches()
        {
            var harmony = HarmonyInstance.Create("krissy.Namegenerator");


            try
            {
                this.Monitor.Log("Postfix patching Dialogue.randomName()", StardewModdingAPI.LogLevel.Debug);
                harmony.Patch(
                    original: AccessTools.Method(typeof(Dialogue), name: "randomName"),
                    postfix: new HarmonyMethod(typeof(patchRandomName), nameof(patchRandomName.Postfix))
                );
            }
            catch (Exception e)
            {
                Monitor.Log($"Failed in Patching Dialogue.randomName(): \n{e}", LogLevel.Error);
                return;
            }
        }
    }
}