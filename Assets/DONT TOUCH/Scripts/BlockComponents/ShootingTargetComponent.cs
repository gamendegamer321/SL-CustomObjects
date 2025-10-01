using System.Collections.Generic;
using UnityEngine;

public class ShootingTargetComponent : SchematicBlock
{
    [Tooltip("The type of target to spawn")]
    public TargetType Type;

    [Tooltip("Whether global stats will be used")]
    public bool IsGlobal;

    public override BlockType BlockType => BlockType.ShootingTarget;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "Type", Type },
            { "Global", IsGlobal }
        };

        base.Compile(block);
    }
}