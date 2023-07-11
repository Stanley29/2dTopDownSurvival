using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private float xMinimum, xMaximum, zMinimum, zMaximum;
    public GameObject [] Buildings;

    private void Start()
    {
        // ... Get Terrain reference and terrainArea
        GameObject go = GameObject.Find("Terrain");
        Terrain terrain = go.GetComponent<Terrain>();

        xMinimum = transform.position.x;
        zMinimum = transform.position.z;
        xMaximum = xMinimum + 80;
        zMaximum = zMinimum + 80;

        for (int i = 0; i < 20; i++)
        {
            InstantiateGameObject(Buildings[Random.Range(0, 3)]);
        }
    }

    private void InstantiateGameObject(GameObject prefab)
    {
        GameObject newGameObject = Instantiate(prefab,
            new Vector3(Random.Range(xMinimum, xMaximum), 0,
            Random.Range(zMinimum, zMaximum)), Quaternion.identity);

        newGameObject.transform.parent = this.transform;
        newGameObject.transform.tag = "Teleportation";
    }
}
