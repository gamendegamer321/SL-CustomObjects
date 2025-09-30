using System.Collections.Generic;
using UnityEngine;

public class CapybaraComponent : SchematicBlock
{
    [Tooltip("Whether players can collide with the capybara.")]
    public bool Collidable = true;

    public override BlockType BlockType => BlockType.Capybara;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "CollidersEnabled", Collidable }
        };

        base.Compile(block);
    }
}