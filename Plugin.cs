using BepInEx;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;
using LethalLib.Modules;

 namespace MoreLethalScraps
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency("evaisa.lethallib", "0.15.1")]
    public class Plugin : BaseUnityPlugin
    {

        const string GUID = "wexop.moreLethalScraps";
        const string NAME = "MoreLethalScraps";
        const string VERSION = "1.0.0";

        public static Plugin instance;

        void Awake()
        {
            instance = this;
            
            Logger.LogInfo($"MoreLethalScraps starting....");

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "morelethalscraps");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            
            Logger.LogInfo($"MoreLethalScraps bundle found !");

            //Dog
            Item dog = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/DogScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(dog.spawnPrefab);
            Utilities.FixMixerGroups(dog.spawnPrefab);
            Items.RegisterScrap(dog, 75, Levels.LevelTypes.All);
            Items.RegisterScrap(dog, 100, Levels.LevelTypes.AssuranceLevel);
            Items.RegisterScrap(dog, 100, Levels.LevelTypes.OffenseLevel);

            Logger.LogInfo($"MoreLethalScraps - DogToy ready !");
            
            //Brakken
            Item brakken = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/BrakkenScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(brakken.spawnPrefab);
            Utilities.FixMixerGroups(brakken.spawnPrefab);
            Items.RegisterScrap(brakken, 50, Levels.LevelTypes.All);
            Items.RegisterScrap(brakken, 80, Levels.LevelTypes.MarchLevel);
            Items.RegisterScrap(brakken, 80, Levels.LevelTypes.VowLevel);
            
            Logger.LogInfo($"MoreLethalScraps - BrakkenToy ready !");
            
            //FireExit
            Item fireExit = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/FireExitScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(fireExit.spawnPrefab);
            Utilities.FixMixerGroups(fireExit.spawnPrefab);
            Items.RegisterScrap(fireExit, 100, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - FireExitToy ready !");
            
            //GoldenFireExit
            Item goldenFireExit = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/GoldenFireExitScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(goldenFireExit.spawnPrefab);
            Utilities.FixMixerGroups(goldenFireExit.spawnPrefab);
            Items.RegisterScrap(goldenFireExit, 10, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - GoldenFireExitToy ready !");
            
            //NutCracker
            Item nutCracker = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/NutCrackerScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(nutCracker.spawnPrefab);
            Utilities.FixMixerGroups(nutCracker.spawnPrefab);
            Items.RegisterScrap(nutCracker, 30, Levels.LevelTypes.All);
            Items.RegisterScrap(nutCracker, 75, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(nutCracker, 75, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(nutCracker, 75, Levels.LevelTypes.TitanLevel);
            
            Logger.LogInfo($"MoreLethalScraps - NutCrackerToy ready !");
            
            //Giant
            Item giant = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/GiantScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(giant.spawnPrefab);
            Utilities.FixMixerGroups(giant.spawnPrefab);
            Items.RegisterScrap(giant, 50, Levels.LevelTypes.All);
            Items.RegisterScrap(giant, 80, Levels.LevelTypes.VowLevel);
            Items.RegisterScrap(giant, 80, Levels.LevelTypes.MarchLevel);
            Items.RegisterScrap(giant, 80, Levels.LevelTypes.None, new []{"Adamance"});
            
            Logger.LogInfo($"MoreLethalScraps - GiantToy ready !");
            
            //OldBird
            Item oldBird = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/OldBirdScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(oldBird.spawnPrefab);
            Utilities.FixMixerGroups(oldBird.spawnPrefab);
            Items.RegisterScrap(oldBird, 20, Levels.LevelTypes.All);
            Items.RegisterScrap(oldBird, 50, Levels.LevelTypes.RendLevel);
            Items.RegisterScrap(oldBird, 50, Levels.LevelTypes.DineLevel);
            Items.RegisterScrap(oldBird, 65, Levels.LevelTypes.TitanLevel);
            Items.RegisterScrap(oldBird, 100, Levels.LevelTypes.None, new []{"Embrion"});
            
            Logger.LogInfo($"MoreLethalScraps - OldBirdToy ready !");
            
            //Blob
            Item blob = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/MoreLethalScraps/BlobScrap.asset");
            NetworkPrefabs.RegisterNetworkPrefab(blob.spawnPrefab);
            Utilities.FixMixerGroups(blob.spawnPrefab);
            Items.RegisterScrap(blob, 40, Levels.LevelTypes.All);
            
            Logger.LogInfo($"MoreLethalScraps - BlobToy ready !");


            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);
            Logger.LogInfo($"MoreLethalScraps is patched!");
        }


    }
}