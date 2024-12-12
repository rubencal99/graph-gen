using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XNode;

public class MapLayoutGenerator : MonoBehaviour
{
    public NodeGraph flowGraph;

    void Start()
    {
        // Clone the graph
        NodeGraph runtimeGraph = flowGraph.Copy() as NodeGraph;

        // Use the cloned graph
        GenerateMapLayout(runtimeGraph);
    }

    // Iterate over the nodes in the graph and access their data.
    void GenerateMapLayout(NodeGraph graph)
    {

        Dictionary<FlowNode, GameObject> nodeToRoomMap = new Dictionary<FlowNode, GameObject>();

        // Instantiate rooms
        //List<Node> nodes = graph.GetNodes();
        //foreach (Node node in graph.nodes)
        //{
        //    if (node == null) continue;

        //    GameObject roomPrefab = GetRoomPrefab(node.roomType);
        //    Vector3 position = GetNodePosition(node); // Implement your own positioning logic

        //    GameObject roomInstance = Instantiate(roomPrefab, position, Quaternion.identity);
        //    nodeToRoomMap[node] = roomInstance;

        //    // Handle entry point
        //    if (node.entryPoint)
        //    {
        //        // Set player start position, etc.
        //    }
        //}

        // Connect rooms based on node connections
        foreach (FlowNode node in graph.nodes)
        {
            if (node == null) continue;

            // retrieves the output port named "output".
            NodePort outputPort = node.GetOutputPort("output");

            
            foreach (NodePort connectedPort in outputPort.GetConnections())
            {
                FlowNode connectedNode = connectedPort.node as FlowNode;
                if (connectedNode != null)
                {
                    // Use the connection information as needed
                    Debug.Log($"Node {node.nodeGUID} is connected to {connectedNode.nodeGUID}");
                }
            }
        }
    }

    GameObject GetRoomPrefab(RoomType roomType)
    {
        //switch (roomType)
        //{
        //    case RoomType.Normal:
        //        return normalRoomPrefab;
        //    case RoomType.Hub:
        //        return hubRoomPrefab;
        //    // Add other cases as needed
        //    default:
        //        return normalRoomPrefab;
        //}
        return null;
    }

    Vector3 GetNodePosition(FlowNode node)
    {
        // Example using node position from the editor
        Vector2 graphPosition = node.position;
        return new Vector3(graphPosition.x, 0, graphPosition.y);
    }

    void CreateRoomConnection(GameObject fromRoom, GameObject toRoom)
    {
        // Implement your connection logic here
        // For example, create a corridor between fromRoom and toRoom
    }
}