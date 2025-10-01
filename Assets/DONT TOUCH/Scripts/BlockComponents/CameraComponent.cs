using System.Collections.Generic;
using UnityEngine;

public class CameraSchematicComponent : SchematicBlock
{
    [Tooltip("The type of the camera")] public CamType Type;

    [Tooltip("The label shown to SCP-079")]
    public string Label;

    [Header("Constraints")] [Tooltip("The constraint to prevent the user from looking too far up/down")]
    public Vector2 VerticalConstraint;

    [Tooltip("The constraint to prevent the user from looking too far left/right")]
    public Vector2 HorizontalConstraint;

    [Tooltip("The constraint to prevent the user from zooming too far in/out")]
    public Vector2 ZoomConstraint;

    public override BlockType BlockType => BlockType.Camera;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "CameraType", Type },
            { "VerticalConstraint", GetString(VerticalConstraint) },
            { "HorizontalConstraint", GetString(HorizontalConstraint) },
            { "ZoomConstraint", GetString(ZoomConstraint) },
            { "Label", Label }
        };

        base.Compile(block);
    }
    
    private static string GetString(Vector2 vector)
    {
        return $"({vector.x},{vector.y})";
    }
}