using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 3f;
    [SerializeField]float spawnHight = 1.2f;
    public GameObject food;


    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            Vector3 pos =(Random.onUnitSphere * transform.localScale.x/2) * spawnHight;
            Instantiate(food, transform.position + pos, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
