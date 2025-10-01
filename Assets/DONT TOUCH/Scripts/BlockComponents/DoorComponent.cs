using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : SchematicBlock
{
    [Tooltip("The type of the door that needs to be spawned.")]
    public DoorType DoorType;

    [Tooltip("Whether to spawn the door opened.")]
    public bool SpawnOpened;

    [Tooltip("Whether the door should be locked when spawned.")]
    public bool Locked;

    [Tooltip("Permissions required for the door.")]
    public KeycardPermissions Permissions;

    public override BlockType BlockType => BlockType.Door;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "DoorType", DoorType },
            { "SpawnOpened", SpawnOpened },
            { "Permissions", Permissions },
            { "Locked", Locked }
        };

        base.Compile(block);
    }
}