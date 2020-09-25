using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

// KO CẦN GẮN VÀO GO NÀO!
// This system updates all entities in the scene with both a RotationSpeed_ForEach and Rotation component.
public class RotationSpeedSystem_ForEach : SystemBase
{
    // OnUpdate runs on the main thread.
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities
            .WithName("RotationSpeedSystem_ForEach") // CÙNG TÊN VỚI LỚP NÀY (CÓ HAY KO CŨNG DC, ÉO HIỂU ĐỂ LÀM GÌ)
            .ForEach((ref Rotation rotation, in RotationSpeed_ForEach rotationSpeed) => // REF HAY IN ĐỀU ĐƯỢC
            {
                rotation.Value = math.mul(
                    math.normalize(rotation.Value), 
                    quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * deltaTime));
            })
            .ScheduleParallel();
    }
}
