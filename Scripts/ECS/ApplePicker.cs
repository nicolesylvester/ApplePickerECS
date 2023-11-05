using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Unity.Entities;
using UnityEngine.Animations;

public struct BasketComponent : IComponentData
{
    public float BottomY;
    public float SpacingY;

    public float numBaskets;
}

public class ApplePicker : MonoBehaviour
{
    public int numBaskets;
    public float basketBottomY;
    public float basketSpacingY;
    public List<GameObject> basketList;

    private class ApplePickerSystem : Baker<ApplePicker>
    {
        public override void Bake(ApplePicker authoring)
        {
           var entity = GetEntity(TransformUsageFlags.Dynamic);
           var propertiesComponent = new BasketComponent
           {
            BottomY = authoring.basketBottomY,
            SpacingY = authoring.basketSpacingY,
            numBaskets = authoring.numBaskets
           };

           AddComponent(entity, propertiesComponent);
        }
    }

    public void AppleMissed() 
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count -1;

        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
