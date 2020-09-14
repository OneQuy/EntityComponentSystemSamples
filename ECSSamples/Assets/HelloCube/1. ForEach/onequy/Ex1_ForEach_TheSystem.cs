using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class Ex1_ForEach_TheSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var t = Time.DeltaTime;
        
        Entities
            .WithName("Ex1_ForEach_TheSystem")
            .ForEach((ref Rotation rotation, ref Ex1_ComponentData data) =>
            {
                Debug.Log(t);
                rotation.Value = math.mul(
                    math.normalize(rotation.Value),
                    quaternion.AxisAngle(math.up(), data.rotateField * t));
            })
            .ScheduleParallel();
    }
}
