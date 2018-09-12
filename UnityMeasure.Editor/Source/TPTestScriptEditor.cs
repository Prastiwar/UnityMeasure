using UnityEditor;
using UnityEngine;

namespace TP.Measurement.Unity.Editor
{
    [CustomEditor(typeof(TPTestScript), true)]
    public class TPTestScriptEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Run Test", GUI.skin.button, null))
            {
                (target as TPTestScript).RunTest();
            }
            base.OnInspectorGUI();
        }
    }
}
