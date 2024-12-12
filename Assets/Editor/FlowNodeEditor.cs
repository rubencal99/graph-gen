using UnityEditor;
using UnityEngine;
using XNodeEditor;
using XNode;

[CustomNodeEditor(typeof(FlowNode))]
public class FlowNodeEditor : NodeEditor
{
    private GUIStyle nodeStyle;
    //public override void OnHeaderGUI()
    //{
    //    // Do not draw the default header
    //}

    // Overrides the default node GUI.
    public override void OnBodyGUI()
    {
        serializedObject.Update();

        FlowNode node = target as FlowNode;

        // Begin custom node GUI
        GUILayout.BeginVertical();


        // Draw the input port
        NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("input"), GUILayout.MinWidth(0));

        // Room Type Field
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("roomType"), new GUIContent("Room Type"));

        // Entry Point Toggle
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("entryPoint"), new GUIContent("Entry Point"));

        // Draw the output port
        NodeEditorGUILayout.PortField(GUIContent.none, target.GetOutputPort("output"), GUILayout.MinWidth(0));

        GUILayout.EndVertical();

        // Add space to increase node height
        GUILayout.Space(30); // Adjust the value to change height


        serializedObject.ApplyModifiedProperties();
    }

    public override int GetWidth()
    {
        return 200; // Set your desired width here
    }

}