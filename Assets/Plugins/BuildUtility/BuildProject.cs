using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;
using Directory = UnityEngine.Windows.Directory;
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;

// ReSharper disable UnusedMember.Global

namespace Unity.Build
{
    public static class BuildProject
    {
        [MenuItem("Build/Build")]
        public static void Build()
        {
            //AddressableAssetSettings.BuildPlayerContent();
            var buildSettings = (BuildConfiguration) AssetDatabase.LoadAssetAtPath(
                "Assets/game.buildconfiguration", typeof(BuildConfiguration));

            //Assert.IsNotNull(buildSettings);
            buildSettings.Build();

            var path = System.IO.Directory.GetCurrentDirectory() + "\\" + "Release" + "\\";
            if (Directory.Exists(path))
            {
                var processStartInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };

                Process.Start(processStartInfo);
            }
        }
    }
}
#endif