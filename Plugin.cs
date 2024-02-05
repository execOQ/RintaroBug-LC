using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RintaroBug.Patches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RintaroBug
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class RintaroBugBase : BaseUnityPlugin
    {

        private const string modGUID = "consequential.RintaroBug";

        private const string modName = "RintaroBug";

        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static RintaroBugBase Instance;

        internal ManualLogSource mls;

        internal static AudioClip[] newSFX;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modName);

            mls.LogInfo($"{modName} is loading...");

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RintaroBug.Audio.rintaro_og_sound");

            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            if (bundle == null)
            {
                mls.LogError("Failed to load audio assets...");
                return;
            }

            newSFX = bundle.LoadAllAssets<AudioClip>();

            harmony.PatchAll(typeof(HoarderBugPatch));

            mls.LogInfo($"{modName} is loaded!");
        }

    }
}