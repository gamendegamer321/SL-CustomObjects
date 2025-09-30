using System.Collections.Generic;
using System.ComponentModel;

public class AmnesticCloudComponent : SchematicBlock
{
    [Description("The duration the amnesia is given to the player")]
    public float AmnesiaDuration;

    [Description("The size of the amnesia circle")]
    public byte Size;

    [Description("The duration the cloud is there")]
    public float Duration;

    public override BlockType BlockType => BlockType.AmnesticCloud;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "AmnesiaDuration", AmnesiaDuration },
            { "Size", Size },
            { "Duration", Duration }
        };

        base.Compile(block);
    }
}