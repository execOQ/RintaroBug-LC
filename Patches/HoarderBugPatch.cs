using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RintaroBug.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void HoarderBugAudioPatch(HoarderBugAI __instance)
        {
            AudioClip[] newSFX = RintaroBugBase.newSFX;
            __instance.chitterSFX = newSFX;

        }
    }
}
