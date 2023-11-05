using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Start is called before the first frame update
    public GameObject applePrefab; // apple prefab

    public GameObject orangePrefab; // orange prefab

    public GameObject rockPrefab;


    public float speed = 15f; // spped of the tree

    public float leftAndRightEdge = 25f; // distance before turning

    public float changeDirectionChance = 0.002f;

    public float appleDropDelay = 0.5f;


    void Start()
    {
        Invoke("DropApple", 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed*Time.deltaTime;
        transform.position = pos;

        // changes the direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }

        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate()
    {
        if(Random.value < changeDirectionChance)
        {
            speed *= -1; // change direction
        }
    }

    public void DropApple()
    {
        GameObject fruitPrefabToDrop;

        float randomValue = Random.Range(0f, 1f);

        if (randomValue < 0.40f) {
        // 40% chance to drop an apple
        fruitPrefabToDrop = applePrefab;
        } 
        else if (randomValue < 0.70f) {
        // 30% chance to drop an orange
        fruitPrefabToDrop = orangePrefab;
        } 
        else {
        // 30% chance to drop a rock
        fruitPrefabToDrop = rockPrefab;
        }
        
        if (fruitPrefabToDrop != null)
        {
            GameObject fruit = Instantiate<GameObject>(fruitPrefabToDrop);
            fruit.transform.position = transform.position;
        }
        Invoke("DropApple", appleDropDelay);
    } 
}
