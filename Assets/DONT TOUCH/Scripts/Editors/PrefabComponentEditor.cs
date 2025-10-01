using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DONT_TOUCH.Scripts.Editors
{
    [CustomEditor(typeof(PrefabComponent))]
    public class PrefabComponentEditor : Editor
    {
        private static readonly Dictionary<string, uint> Prefabs = new()
        {
            { "Broken Electrical Box Open Connector", 3999209566 },
            { "Simple Boxes Open Connector", 1687661105 },
            { "Pipes Short Open Connector", 147203050 },
            { "Boxes Ladder Open Connector", 1102032353 },
            { "Tank-Supported Shelf Open Connector", 2490430134 },
            { "Angled Fences Open Connector", 2673083832 },
            { "Huge Orange Pipes Open Connector", 2536312960 },
            { "Pipes Long Open Connector", 38976586 }
        };

        private static string[] Options => Prefabs.Keys.ToArray();

        public override void OnInspectorGUI()
        {
            var component = (PrefabComponent)target;

            var oldManual = component.ManualSelection;
            component.ManualSelection = GUILayout.Toggle(component.ManualSelection, "Manual input");

            var changedManual = oldManual != component.ManualSelection;
            GUILayout.Space(10);

            if (component.ManualSelection)
            {
                component.Selected = GUILayout.TextField(component.Selected);
            }
            else
            {
                var previous = component.SelectedIndex;
                component.SelectedIndex = EditorGUILayout.Popup(component.SelectedIndex, Options);

                if (previous != component.SelectedIndex || changedManual)
                {
                    component.Selected = Prefabs[Options[component.SelectedIndex]].ToString();
                }
            }
        }
    }
}