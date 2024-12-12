using UnityEngine;
using XNode;

public class FlowNode : Node
{
    // Define ports for the node.
    [Input(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
    public FlowNode input;

    [Output(connectionType = ConnectionType.Multiple)]
    public FlowNode output;


    // Serialized fields to store node-specific data.
    [SerializeField]
    public RoomType roomType = RoomType.Normal;

    [SerializeField]
    public bool entryPoint = false;

    public string nodeGUID;

    // Initializes the node when it's created.
    protected override void Init()
    {
        base.Init();
        // Generate a unique identifier
        nodeGUID = System.Guid.NewGuid().ToString();
    }

    public override object GetValue(NodePort port)
    {
        // Return the value of this node (not used in this context)
        return null;
    }
}