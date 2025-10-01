using System;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorComponent : SchematicBlock
{
    [Tooltip("The type of elevator that will be spawned")]
    public ElevatorType Type;

    [Tooltip("The index of the initial door")]
    public int InitialDoor;

    [Tooltip("The doors the elevator can travel to")]
    public ElevatorDoor[] Doors;

    public override BlockType BlockType => BlockType.Elevator;

    public override void Compile(SchematicBlockData block)
    {
        var properties = new Dictionary<string, object>
        {
            { "ElevatorType", Type },
            { "InitialDoor", InitialDoor },
            { "DoorCount", Doors.Length }
        };

        for (var i = 0; i < Doors.Length; i++)
        {
            Doors[i].Add(i, properties);
        }

        block.Properties = properties;

        base.Compile(block);
    }

    [Serializable]
    public struct ElevatorDoor
    {
        [Tooltip("The position where the door is located")]
        public Transform DoorPosition;

        [Tooltip("The position the elevator will try to go to")]
        public Transform TargetPosition;

        [Tooltip("The position the elevator will pass when exiting upwards")]
        public Transform TopPosition;

        [Tooltip("The position the elevator will pass when exiting downwards")]
        public Transform BottomPosition;

        public void Add(int index, Dictionary<string, object> properties)
        {
            properties[$"Door-{index}-doorPosition"] = GetString(DoorPosition.position);
            properties[$"Door-{index}-targetPosition"] = GetString(TargetPosition.position);
            properties[$"Door-{index}-topPosition"] = GetString(TopPosition.position);
            properties[$"Door-{index}-bottomPosition"] = GetString(BottomPosition.position);
        }

        private static string GetString(Vector3 vector)
        {
            return $"({vector.x},{vector.y},{vector.z})";
        }
    }
}