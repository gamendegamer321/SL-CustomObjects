using System.Collections.Generic;
using UnityEngine;

public class GeneratorComponent : SchematicBlock
{
    [Tooltip("The permissions required to unlock the generator")]
    public KeycardPermissions Permissions;

    [Tooltip("The time it takes for the generator to be activated")]
    public float ActivationTime;

    [Tooltip("The time it takes the generator to completely decharge after its disabled")]
    public float DeactivationTime;

    [Tooltip("Whether the generator is spawned open")]
    public bool Open;

    [Tooltip("Whether the generator is unlocked when spawned")]
    public bool Unlocked;

    [Tooltip("Whether the generator is already engaged when spawned")]
    public bool Engaged;

    public override BlockType BlockType => BlockType.Generator;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "RequiredPermissions", Permissions },
            { "ActivationTime", ActivationTime },
            { "DeactivationTime", DeactivationTime },
            { "IsOpen", Open },
            { "IsUnlocked", Unlocked },
            { "Engaged", Engaged }
        };

        base.Compile(block);
    }
}