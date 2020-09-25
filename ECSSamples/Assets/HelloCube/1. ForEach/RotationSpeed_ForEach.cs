using System;
using Unity.Entities;

// CẦN GẮN VÀO GO!
// LÀ STRUCT

[GenerateAuthoringComponent]
public struct RotationSpeed_ForEach : IComponentData
{
    public float RadiansPerSecond;
}
