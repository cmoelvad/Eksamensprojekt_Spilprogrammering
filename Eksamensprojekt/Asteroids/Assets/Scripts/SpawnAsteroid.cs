using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public Rigidbody2D[] asteroids = new Rigidbody2D[3];
    public float minimumSpawnDegree;
    public float maximumSpawnDegree;
    [Range(0, 1)]
    public int xyChange = 0;
    public int asteroidSpeed = 4;
    public Transform spawnpoint;
    public float spawnRate = 1f;
    [Range(0,100)]
    public int spawnChanceInPercent = 20;
    private float lastCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheck > spawnRate)
        {
            bool spawnable = (int)(Random.value * 100) < spawnChanceInPercent;
            if (spawnable)
            {
                if(xyChange == 0)
                {
                    spawnpoint.position = new Vector3(spawnpoint.position.x, Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2), spawnpoint.position.z);
                }
                else
                {
                    spawnpoint.position = new Vector3(Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2), spawnpoint.position.y, spawnpoint.position.z);
                }
                spawnpoint.rotation = Quaternion.Euler(0, 0, Random.Range(minimumSpawnDegree, maximumSpawnDegree));

                Vector2 direction = spawnpoint.TransformDirection(Vector2.up);
                Rigidbody2D asteroidInstance = Instantiate(asteroids[(int)(Random.value * 3)], spawnpoint.transform.position, spawnpoint.transform.rotation);

                Vector2 force = direction * asteroidSpeed;
                asteroidInstance.AddForce(force, ForceMode2D.Impulse);
                if(spawnChanceInPercent < 100)
                {
                    spawnChanceInPercent += 1;
                }
            }

            lastCheck = Time.time;
        }
    }
}