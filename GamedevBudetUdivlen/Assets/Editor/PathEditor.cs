using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

        Path myScript = (Path)target;
		if (GUILayout.Button("Form path"))
		{
            myScript.FormPath();
		}
	}
}