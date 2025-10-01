using System.Collections.Generic;

public class PrefabComponent : SchematicBlock
{
    public bool ManualSelection;
    public string Selected;
    public int SelectedIndex;

    public override BlockType BlockType => BlockType.Prefab;

    public override void Compile(SchematicBlockData block)
    {
        block.Properties = new Dictionary<string, object>
        {
            { "Prefab", Selected }
        };

        base.Compile(block);
    }
}