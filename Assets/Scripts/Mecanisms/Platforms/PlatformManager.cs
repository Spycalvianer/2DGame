using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlatformManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        PlatformSelector plataforma = (PlatformSelector)target;
        if (GUILayout.Button("Configurar"))
        {

        }
    }
}
