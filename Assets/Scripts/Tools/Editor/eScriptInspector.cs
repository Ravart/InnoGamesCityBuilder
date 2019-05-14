using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(MonoScript))]
public class eScriptInspector : Editor {

	public override void OnInspectorGUI()
	{

		MonoScript ms = target as MonoScript;
		System.Type type = ms.GetClass();


		if (type != null && type.IsSubclassOf(typeof(ScriptableObject)) && !type.IsSubclassOf(typeof(UnityEditor.Editor)))
		{
			if (GUILayout.Button("Create Instance"))
			{
				ScriptableObject asset = ScriptableObject.CreateInstance(type);
				string path = AssetDatabase.GenerateUniqueAssetPath("Assets/" + type.Name + ".asset");
				AssetDatabase.CreateAsset(asset, path);
				EditorGUIUtility.PingObject(asset);
			}
		}
	}
}
