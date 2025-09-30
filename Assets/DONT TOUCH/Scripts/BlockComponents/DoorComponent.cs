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

    [Header("Breakable door settings")] [Tooltip("Health the door spawns with")]
    public float Health = 80f;

    [Tooltip("The damage sources that should be ignored for this door")]
    public DoorDamageType IgnoredDamageSources;

    [Tooltip("Whether to spawn the door destroyed.")]
    public bool Destroyed;

    [Tooltip("Whether the player can interact with the door")]
    public bool Interactable = true;

    [Tooltip("Whether SCP-106 can walk through the door")]
    public bool Scp106Passable = true;

    public override BlockType BlockType => BlockType.Door;

    public override void Compile(SchematicBlockData block)
    {
        var properties = new Dictionary<string, object>
        {
            { "DoorType", DoorType },
            { "SpawnOpened", SpawnOpened },
            { "Permissions", Permissions },
            { "Locked", Locked }
        };

        if (DoorType == DoorType.LightContainmentDoor ||
            DoorType == DoorType.HeavyContainmentDoor ||
            DoorType == DoorType.EntranceDoor)
        {
            properties["Health"] = Health;
            properties["IgnoredDamageSources"] = IgnoredDamageSources;
            properties["IsDestroyed"] = Destroyed;
            properties["Interactable"] = Interactable;
            properties["Scp106Passable"] = Scp106Passable;
        }

        block.Properties = properties;

        base.Compile(block);
    }
}