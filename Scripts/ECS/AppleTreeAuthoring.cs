using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public struct AppleECS : IComponentData
{
    public float3 Velocity;
}

public class AppleTreeAuthoring : MonoBehaviour
{
    public float speed;
    public float leftAndRightEdge;
    public float changeDirectionChance;
    
    private class AppleTreeBaker : Baker<AppleTreeAuthoring>
    {
        public override void Bake(AppleTreeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new AppleTreeProperties
            {
                Speed = authoring.speed,
                LeftAndRightEdge = authoring.leftAndRightEdge,
                ChangeDirectionChance = authoring.changeDirectionChance,
                Random = Random.CreateFromIndex((uint)entity.Index)
            };
            
            AddComponent(entity, propertiesComponent);
        }
    }
}

public struct AppleTreeProperties : IComponentData
{
    public float Speed;
    public float LeftAndRightEdge;
    public float ChangeDirectionChance;

    public Random Random;
}