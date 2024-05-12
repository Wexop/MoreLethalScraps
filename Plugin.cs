using BepInEx;
using HarmonyLib;
using System.IO;
using System.Reflection;
using BepInEx.Configuration;
using UnityEngine;
using LethalLib.Modules;
using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace MoreLethalScraps
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency("evaisa.lethallib", "0.15.1")]
    [BepInDependency("ainavt.lc.lethalconfig")]
    public class Plugin : BaseUnityPlugin
    {

        const string GUID = "wexop.moreLethalScraps";
        const string NAME = "MoreLethalScraps";
        const string VERSION = "1.1.0";

        public static Plugin instance;

        void Awake()
        {
            instance = this;

            Logger.LogInfo($"MoreLethalScraps starting....");

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "morelethalscraps");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            
            Logger.LogInfo($"MoreLethalScraps bundle found !");

            var scrapRarityDesc =
                "The chance of finding an object, 0 is null 100 is a lot. Common game craps items are between 0 and 100 Warning: restart the game for the change to take effect.";

            //Dog
            Item dog = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/DogScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(dog.spawnPrefab);
            Utilities.FixMixerGroups(dog.spawnPrefab);
            
            var dogAllEntry = Config.Bind("ScrapsRarity", "DogToy All moons", 65, scrapRarityDesc);
            CreateSliderScrap(dogAllEntry);
            var dogSpecialMoonsEntry = Config.Bind("ScrapsRarity", "DogToy Assurance and Offense moons", 100, scrapRarityDesc);
            CreateSliderScrap(dogSpecialMoonsEntry);

            Items.RegisterScrap(dog, dogSpecialMoonsEntry.Value, Levels.LevelTypes.AssuranceLevel);
            Items.RegisterScrap(dog, dogSpecialMoonsEntry.Value, Levels.LevelTypes.OffenseLevel);
            Items.RegisterScrap(dog, dogAllEntry.Value, Levels.LevelTypes.All);

            Logger.LogInfo($"MoreLethalScraps - DogToy ready !");
            
            //Brakken
            Item brakken = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/BrakkenScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(brakken.spawnPrefab);
            Utilities.FixMixerGroups(brakken.spawnPrefab);
            
            var brackenAllEntry = Config.Bind("ScrapsRarity", "BrackenToy All moons", 50, scrapRarityDesc);
            CreateSliderScrap(brackenAllEntry);
            var brackenSpecialMoonsEntry = Config.Bind("ScrapsRarity", "BrackenToy March and Vow moons", 80, scrapRarityDesc);
            CreateSliderScrap(brackenSpecialMoonsEntry);

            Items.RegisterScrap(brakken, brackenSpecialMoonsEntry.Value, Levels.LevelTypes.MarchLevel);
            Items.RegisterScrap(brakken, brackenSpecialMoonsEntry.Value, Levels.LevelTypes.VowLevel);
            Items.RegisterScrap(brakken, brackenAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - BrakkenToy ready !");
            
            //FireExit
            Item fireExit = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/FireExitScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(fireExit.spawnPrefab);
            Utilities.FixMixerGroups(fireExit.spawnPrefab);
            
            var fireExitAllEntry = Config.Bind("ScrapsRarity", "FireExitToy All moons", 100, scrapRarityDesc);
            CreateSliderScrap(fireExitAllEntry);
            
            Items.RegisterScrap(fireExit, fireExitAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - FireExitToy ready !");
            
            //GoldenFireExit
            Item goldenFireExit = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/GoldenFireExitScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(goldenFireExit.spawnPrefab);
            Utilities.FixMixerGroups(goldenFireExit.spawnPrefab);
            
            var goldenFireExitAllEntry = Config.Bind("ScrapsRarity", "GoldenFireExitToy All moons", 5, scrapRarityDesc);
            CreateSliderScrap(goldenFireExitAllEntry);
            
            Items.RegisterScrap(goldenFireExit, goldenFireExitAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - GoldenFireExitToy ready !");
            
            //NutCracker
            Item nutCracker = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/NutCrackerScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(nutCracker.spawnPrefab);
            Utilities.FixMixerGroups(nutCracker.spawnPrefab);
            
            var nutCrackerAllEntry = Config.Bind("ScrapsRarity", "NutCrackerToy All moons", 30, scrapRarityDesc);
            CreateSliderScrap(nutCrackerAllEntry);
            var nutCrackerSpecialMoonsEntry = Config.Bind("ScrapsRarity", "NutCrackerToy Rend, Dine and Titan moons", 75, scrapRarityDesc);
            CreateSliderScrap(nutCrackerSpecialMoonsEntry);

            Items.RegisterScrap(nutCracker, nutCrackerSpecialMoonsEntry.Value, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(nutCracker, nutCrackerSpecialMoonsEntry.Value, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(nutCracker, nutCrackerSpecialMoonsEntry.Value, Levels.LevelTypes.TitanLevel);
            Items.RegisterScrap(nutCracker, nutCrackerAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - NutCrackerToy ready !");
            
            //Giant
            Item giant = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/GiantScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(giant.spawnPrefab);
            Utilities.FixMixerGroups(giant.spawnPrefab);
            
            var giantAllEntry = Config.Bind("ScrapsRarity", "GiantToy All moons", 40, scrapRarityDesc);
            CreateSliderScrap(giantAllEntry);
            var giantSpecialMoonsEntry = Config.Bind("ScrapsRarity", "GiantToy March, Vow and Adamance moons", 80, scrapRarityDesc);
            CreateSliderScrap(giantSpecialMoonsEntry);

            Items.RegisterScrap(giant, giantSpecialMoonsEntry.Value, Levels.LevelTypes.VowLevel);
            Items.RegisterScrap(giant, giantSpecialMoonsEntry.Value, Levels.LevelTypes.MarchLevel);
            Items.RegisterScrap(giant, giantSpecialMoonsEntry.Value, Levels.LevelTypes.None, new []{"Adamance"});
            Items.RegisterScrap(giant, giantAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - GiantToy ready !");
            
            //OldBird
            Item oldBird = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/OldBirdScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(oldBird.spawnPrefab);
            Utilities.FixMixerGroups(oldBird.spawnPrefab);
            
            var oldBirdAllEntry = Config.Bind("ScrapsRarity", "OldBirdToy All moons", 25, scrapRarityDesc);
            CreateSliderScrap(oldBirdAllEntry);
            var oldBirdSpecialMoonsEntry = Config.Bind("ScrapsRarity", "OldBirdToy Rend, Dine and Titan moons", 50, scrapRarityDesc);
            CreateSliderScrap(oldBirdSpecialMoonsEntry);
            var oldBirdEmbrionEntry = Config.Bind("ScrapsRarity", "OldBirdToy Embrion moon", 100, scrapRarityDesc);
            CreateSliderScrap(oldBirdEmbrionEntry);

            Items.RegisterScrap(oldBird, oldBirdSpecialMoonsEntry.Value, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(oldBird, oldBirdSpecialMoonsEntry.Value, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(oldBird, oldBirdSpecialMoonsEntry.Value, Levels.LevelTypes.TitanLevel);
            Items.RegisterScrap(oldBird, oldBirdEmbrionEntry.Value, Levels.LevelTypes.None, new []{"Embrion"});
            Items.RegisterScrap(oldBird, oldBirdAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - OldBirdToy ready !");
            
            //Blob
            Item blob = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/BlobScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(blob.spawnPrefab);
            Utilities.FixMixerGroups(blob.spawnPrefab);
            
            var blobAllEntry = Config.Bind("ScrapsRarity", "BlobToy All moons", 40, scrapRarityDesc);
            CreateSliderScrap(blobAllEntry);
            
            Items.RegisterScrap(blob, blobAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - BlobToy ready !");
            
            //BugToy
            Item bug = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/BugScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(bug.spawnPrefab);
            Utilities.FixMixerGroups(bug.spawnPrefab);
            
            var bugAllEntry = Config.Bind("ScrapsRarity", "BugToy All moons", 75, scrapRarityDesc);
            CreateSliderScrap(bugAllEntry);
            
            Items.RegisterScrap(bug, bugAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - BugToy ready !");
            
            //CoilHead
            Item coilHead = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/CoilHeadScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(coilHead.spawnPrefab);
            Utilities.FixMixerGroups(coilHead.spawnPrefab);
            
            var coilAllEntry = Config.Bind("ScrapsRarity", "CoilHeadToy All moons", 22, scrapRarityDesc);
            CreateSliderScrap(coilAllEntry);
            
            var coilSpecialMoonsEntry = Config.Bind("ScrapsRarity", "CoilHeadToy Rend, Dine and Titan moons", 65, scrapRarityDesc);
            CreateSliderScrap(coilSpecialMoonsEntry);
            
            Items.RegisterScrap(coilHead, coilSpecialMoonsEntry.Value, Levels.LevelTypes.TitanLevel);
            Items.RegisterScrap(coilHead, coilSpecialMoonsEntry.Value, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(coilHead, coilSpecialMoonsEntry.Value, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(coilHead, coilAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - CoilHeadToy ready !");
            
                        
            //JesterToy
            Item jester = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/JesterScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(jester.spawnPrefab);
            Utilities.FixMixerGroups(jester.spawnPrefab);
            
            var jesterAllEntry = Config.Bind("ScrapsRarity", "JesterToy All moons", 20, scrapRarityDesc);
            CreateSliderScrap(jesterAllEntry);
            
            var jesterSpecialMoonsEntry = Config.Bind("ScrapsRarity", "JesterToy Rend, Dine and Titan moons", 50, scrapRarityDesc);
            CreateSliderScrap(jesterSpecialMoonsEntry);
            
            Items.RegisterScrap(jester, jesterSpecialMoonsEntry.Value, Levels.LevelTypes.TitanLevel);
            Items.RegisterScrap(jester, jesterSpecialMoonsEntry.Value, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(jester, jesterSpecialMoonsEntry.Value, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(jester, jesterAllEntry.Value, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - JesterToy ready !");


            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);
            Logger.LogInfo($"MoreLethalScraps is patched!");
        }

        private void CreateSliderScrap( ConfigEntry<int> configEntry)
        {
            var exampleSlider = new IntSliderConfigItem(configEntry, new IntSliderOptions 
            {
                Min = 0,
                Max = 100
            });
            LethalConfigManager.AddConfigItem(exampleSlider);
        }


    }
}