#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Build;
using System.Linq;
using System.IO;
using System.Collections;
using System;
using System.Collections.Generic;

namespace ModBuilder {
    public class SpellicModExporter : EditorWindow
    {
        // Consts
        const string MOD_INFO_PATH = "Assets/ModInfo.json";

        // State
        string exportPath = "";
        ModInfo modInfo;

        [MenuItem("Spellic/Export Mod")]
        public static void ShowExportWindow()
        {
            GetWindow<SpellicModExporter>("SpellicModExporter");
        }

        private void Awake()
        {
            exportPath = FormatPath(Application.dataPath + "/Export");
        }

        private void OnEnable()
        {
            ReadJSON();
        }

#region GUI
        private void OnGUI()
        {
            if(GUILayout.Button("Create Thumbnail", GUILayout.Height(40)))
            {
                this.CreateThumbnail();
            }

            if(GUILayout.Button("Build Mod", GUILayout.Height(40)))
            {
                // Read JSON again
                ReadJSON();

                // TODO: Validate problably

                // Check Path
                if (Directory.Exists(exportPath)) DeleteFolder(exportPath);

                // Build
                Config();
                Export();

                // Open Path
                EditorUtility.RevealInFinder(exportPath);
            }
        }
#endregion

#region Export
        void Config()
        {
            if (!File.Exists(exportPath)) CreateFolder(exportPath);

            // Write JSON
            File.WriteAllText(FormatPath(exportPath + "/ModInfo.json"), JsonUtility.ToJson(modInfo));
        }

        void Export()
        {
            // Switch to Windows
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
            EditorUserBuildSettings.selectedStandaloneTarget = BuildTarget.StandaloneWindows64;

            // Export Windows
            Bundle();

            // Switch to Linux
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneLinux64);
            EditorUserBuildSettings.selectedStandaloneTarget = BuildTarget.StandaloneLinux64;

            // Export Linux
            Bundle();

            // Switch to MacOSX
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
            EditorUserBuildSettings.selectedStandaloneTarget = BuildTarget.StandaloneOSX;
            //EditorUserBuildSettings.SetPlatformSettings("Standalone", "OSX", "Architecture", "x64ARM64");

            // Export
            Bundle();
        }

        void Bundle()
        {
            // Cleanup
            string build_path = FormatPath(exportPath + "/" + EditorUserBuildSettings.selectedStandaloneTarget);
            if (Directory.Exists(build_path)) DeleteFolder(build_path);

            // Create Asset Bundle
            var group = AddressableAssetSettingsDefaultObject.Settings.FindGroup("Default Local Group");
            if (group == null) return;

            foreach(AddressableAssetEntry entry in group.entries.ToList())
            {
                group.RemoveAssetEntry(entry);
            }

            // Entity List
            var entries = new List<AddressableAssetEntry>();

            // Add Map
            var mapGUID = AssetDatabase.AssetPathToGUID(modInfo.map.path);
            if(mapGUID != null)
            {
                entries.Add(AddEntry(mapGUID, group, "Map"));
            }

            // Add Thumbnail
            var thumbnailGUID = AssetDatabase.AssetPathToGUID(modInfo.thumbnail);
            if(thumbnailGUID != null)
            {
                entries.Add(AddEntry(thumbnailGUID, group, "Thumbnail"));
            }

            // TODO: GameModeManager
            // Add GameModeFile
            var gameModeFileGUID = AssetDatabase.AssetPathToGUID(modInfo.gamemode.path);
            if(gameModeFileGUID != null)
            {
                entries.Add(AddEntry(gameModeFileGUID, group, "GameModeFile"));
            }

            // Add Entries
            group.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, entries, false, true);
            AddressableAssetSettingsDefaultObject.Settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, entries, true, false);

            // Set Path
            AddressableAssetSettingsDefaultObject.Settings.profileSettings.SetValue(
                AddressableAssetSettingsDefaultObject.Settings.activeProfileId,
                "Local.LoadPath",
                "{LOCAL_MOD_PATH}"
            );

            AddressableAssetSettingsDefaultObject.Settings.profileSettings.SetValue(
                AddressableAssetSettingsDefaultObject.Settings.activeProfileId,
                "Local.BuildPath",
                build_path
            );

            // Export
            AddressableAssetSettings.CleanPlayerContent(AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
            AddressableAssetSettings.BuildPlayerContent(out AddressablesPlayerBuildResult result);
        }

        AddressableAssetEntry AddEntry(string GUID, AddressableAssetGroup group, string label)
        {
            var e = AddressableAssetSettingsDefaultObject.Settings.CreateOrMoveEntry(GUID, group, false, false);
            e.SetLabel(label, true, true, false);
            return e;
        }
#endregion

#region Utils
        public string FormatPath(string path)
        {
            return path.Replace(@"\", "/");
        }

        public void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteFolder(string path)
        {
            if (!Directory.Exists(path)) return;
            FileUtil.DeleteFileOrDirectory(path);
        }

        public void ReadJSON()
        {
            // Read JSON File
            TextAsset json = (TextAsset) AssetDatabase.LoadAssetAtPath("Assets/ModInfo.json", typeof(TextAsset));

            // Create Mod Info
            this.modInfo = ModInfo.FromJSON(json.text);
        }

        public void CreateThumbnail()
        {
            // Create Path
            string path = FormatPath(Application.dataPath + "/Thumbnail.png");

            // Create RenderTexture
            RenderTexture screenTexture = new RenderTexture(1280, 720, 16);
            Camera.allCameras[0].targetTexture = screenTexture;
            RenderTexture.active = screenTexture;
            // Render One Frame
            Camera.allCameras[0].Render();
            // Create Texture
            Texture2D thumbnail = new Texture2D(1280, 720);
            thumbnail.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            // Reset Texture
            RenderTexture.active = null;
            byte[] byteArray = thumbnail.EncodeToPNG();
            File.WriteAllBytes(path, byteArray);
            AssetDatabase.Refresh();
        }
#endregion
    }

    [System.Serializable]
    public class ModInfo
    {
        public string name;
        public string author;
        public string version;
        public string gameVersion;
        public string thumbnail;
        public string[] dependencies;
        public ModMap map;
        public ModGameMode gamemode;

        public static ModInfo FromJSON(string json)
        {
            return JsonUtility.FromJson<ModInfo>(json);
        }
    }

    [System.Serializable]
    public class ModMap
    {
        public string name;
        public string description;
        public string[] gamemodes;
        public MapMob[] mobs;
        public string path;
        public MapSettings settings;
    }

    [System.Serializable]
    public class MapSettings
    {
        public float gravityMultiplier = 1;
        public float contrastLevel = 1;
    }

    [System.Serializable]
    public class ModGameMode
    {
        public string name;
        public string path;
        public bool teamBased;
        public bool allowMobs;
        public bool hasDifficulty;
        public bool hasRounds;
        public bool hasRoundTime;
        public string compatible;
        public int[] rounds;
        public int[] roundTimes;
    }

    [System.Serializable]
    public class MapMob
    {
        public string name;
        public float spawnChance;
    }
}
#endif