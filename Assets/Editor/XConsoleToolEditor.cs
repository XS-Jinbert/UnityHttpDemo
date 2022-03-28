using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

public class XDebugKeyCode
{
    [MenuItem("XDebug/辅助型功能/清除控制台 _F1", false, 1)]
    public static void ClearConsole()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
        Type logEntries = assembly.GetType("UnityEditor.LogEntries");
        MethodInfo clearConsoleMethod = logEntries.GetMethod("Clear");
        clearConsoleMethod.Invoke(new object(), null);
    }
}
