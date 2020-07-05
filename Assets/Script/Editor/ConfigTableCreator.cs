using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ConfigTableCreator : Editor 
{
    private const string FOLDER = "Assets/Resources/ConfigTables";

    [MenuItem("ConfigTableCreator/CreateCardSkillConfig")]
    public static void CreateCardSkillConfig()
    {
        TryCreateFolder();
        string path = FOLDER + "/CardSkillConfig.asset";
        CardSkillConfigTable scriptableObj = ScriptableObject.CreateInstance<CardSkillConfigTable>();
        AssetDatabase.CreateAsset(scriptableObj, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }   
    [MenuItem("ConfigTableCreator/CreateCardConfig")]
    public static void CreateCardConfig()
    {
        TryCreateFolder();
        string path = FOLDER + "/CardConfig.asset";
        CardConfigTable scriptableObj = ScriptableObject.CreateInstance<CardConfigTable>();
        AssetDatabase.CreateAsset(scriptableObj, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }



    private static void TryCreateFolder()
    {
        if (!Directory.Exists(FOLDER))
        {
            Directory.CreateDirectory(FOLDER);
        }
    }
}
