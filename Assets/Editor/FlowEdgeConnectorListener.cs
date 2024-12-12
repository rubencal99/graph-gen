using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowEdgeConnectorListener : IEdgeConnectorListener
{
    // Optional method to handle edges dropped outside any port.
    public void OnDropOutsidePort(Edge edge, Vector2 position)
    {
        Debug.Log("OnDropOutsidePort called");
        Debug.Log("Edge input: " + edge.input);
        Debug.Log("Edge output: " + edge.output);
        // Handle when an edge is dropped outside any port (optional)
    }

    // Handles the creation of a new edge when a connection is made between two ports.
    public void OnDrop(GraphView graphView, Edge edge)
    {
        Debug.Log("OnDrop: Entering");
        // Ensure both ports are valid
        if (edge.input == null || edge.output == null)
            return;

        // Prevent connecting a port to itself
        if (edge.input.node == edge.output.node)
            return;

        Debug.Log("OnDrop: Edges Valid");
        // Check for existing connections between the same ports
        var existingEdge = edge.input.connections.FirstOrDefault(e => e.output == edge.output);
        if (existingEdge != null)
        {
            // Connection already exists
            Debug.Log("OnDrop: This connection already exists");
            return;
        }

        
        // Add the edge to the graph
        graphView.AddElement(edge);
        Debug.Log("OnDrop: Edges Connected and Added to graphView");
    }
}
