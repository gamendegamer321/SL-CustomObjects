using UnityEngine;

public class BreakableDoorComponent : DoorComponent
{
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

    public override void Compile(SchematicBlockData block)
    {
        base.Compile(block);

        var properties = block.Properties;
        properties["Health"] = Health;
        properties["IgnoredDamageSources"] = IgnoredDamageSources;
        properties["IsDestroyed"] = Destroyed;
        properties["Interactable"] = Interactable;
        properties["Scp106Passable"] = Scp106Passable;
    }
}