using System.Collections.Generic;
using UnityEngine;

public class TantrumComponent : SchematicBlock
{
    [Tooltip("Override the delay speed of the tantrum, use -1 to not change the speed")]
    public float DecaySpeed = -1;

    [Tooltip("Override the duration of the tantrum")]
    public float Duration;

    public override BlockType BlockType => BlockType.Tantrum;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "DecaySpeedOverride", DecaySpeed },
            { "Duration", Duration }
        };

        base.Compile(block);
    }
}