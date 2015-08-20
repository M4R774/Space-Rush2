using UnityEngine;
using UnityEditor;
using System.Collections;

public static class CommandLineBuilds {

	static string[] GetScenePaths() {
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
		
		for(int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
		
		return scenes;
	}
	[MenuItem("File/AutoBuilder/Android")]
	public static void BuildAndroid() {
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
		BuildPipeline.BuildPlayer(GetScenePaths(), "android.apk", BuildTarget.Android, BuildOptions.None);
	}
}
