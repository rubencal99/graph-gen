//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UIElements;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.UIElements;
//using System.IO;

//public class FlowEditorWindow : EditorWindow
//{
//    private FlowGraphView graphView;

//    // Adds a menu item under Tools > Flow Editor to open the editor window.
//    [MenuItem("Tools/Flow Editor")]
//    public static void OpenFlowEditor()
//    {
//        FlowEditorWindow window = GetWindow<FlowEditorWindow>("Flow Editor");
//        window.Show();
//    }

//    // Called when the window is opened; it constructs the graph view and toolbar.
//    private void OnEnable()
//    {
//        ConstructGraphView();
//        GenerateToolbar();
//    }

//    // Cleans up when the window is closed.
//    private void OnDisable()
//    {
//        rootVisualElement.Remove(graphView);
//    }

//    // Initializes the graph view and adds it to the window.
//    private void ConstructGraphView()
//    {
//        graphView = new FlowGraphView
//        {
//            name = "Flow Graph"
//        };

//        graphView.StretchToParentSize();
//        rootVisualElement.Add(graphView);
//    }

//    // Creates a toolbar with a button to add new nodes.
//    private void GenerateToolbar()
//    {
//        var toolbar = new Toolbar();

//        var nodeCreateButton = new Button(() =>
//        {
//            graphView.CreateNode("Room");
//        })
//        {
//            text = "Add Room Node"
//        };

//        // Handle the file dialog and call the respective methods in FlowGraphView.
//        var saveButton = new Button(() =>
//        {
//            SaveData();
//        })
//        {
//            text = "Save Graph"
//        };

//        var loadButton = new Button(() =>
//        {
//            LoadData();
//        })
//        {
//            text = "Load Graph"
//        };

//        toolbar.Add(nodeCreateButton);
//        toolbar.Add(saveButton);
//        toolbar.Add(loadButton);

//        rootVisualElement.Add(toolbar);
//    }

//    // Opens a dialog to save the graph as a .asset file.
//    private void SaveData()
//    {
//        string fileName = EditorUtility.SaveFilePanelInProject("Save Flow Graph", "New Flow Graph", "asset", "Please enter a file name to save the flow graph to");
//        if (!string.IsNullOrEmpty(fileName))
//        {
//            graphView.SaveGraph(Path.GetFileNameWithoutExtension(fileName));
//        }
//    }

//    // Opens a dialog to select a .asset file to load.
//    private void LoadData()
//    {
//        string filePath = EditorUtility.OpenFilePanel("Load Flow Graph", "Assets/Resources", "asset");
//        if (!string.IsNullOrEmpty(filePath))
//        {
//            string fileName = Path.GetFileNameWithoutExtension(filePath);
//            graphView.LoadGraph(fileName);
//        }
//    }
//}
