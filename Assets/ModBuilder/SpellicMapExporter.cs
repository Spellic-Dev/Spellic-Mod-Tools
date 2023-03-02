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
            if(GUILayout.Button("Build Mod", GUILayout.Height(40)))
            {
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
                var e = AddressableAssetSettingsDefaultObject.Settings.CreateOrMoveEntry(mapGUID, group, false, false);
                entries.Add(e);
                e.SetLabel("Map", true, true, false);
            }


            // TODO: GameModeManager

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
        #endregion
    }

    [System.Serializable]
    class ModInfo
    {
        public string name;
        public string author;
        public string version;
        public string[] dependencies;
        public Map map;
        public GameMode gamemode;

        public static ModInfo FromJSON(string json)
        {
            return JsonUtility.FromJson<ModInfo>(json);
        }
    }

    [System.Serializable]
    class Map
    {
        public string name;
        public string description;
        public string[] gamemodes;
        public string path;
    }

    [System.Serializable]
    class GameMode
    {
        public string name;
        public string path;
    }
}
#endif