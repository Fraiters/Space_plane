using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{
    public Transform asteroids;
    public float minDelay, maxDelay; // задержка между запусками
    private float nextLaunchTime; // время следующего запуска
    private float difficulty = 1.0f;

    // Update is called once per frame
    private void Update()
    {
        if (GameControllerScript.instance.isStarted == false)
        {
            return;
        }

        if (Time.time > nextLaunchTime)
        {
            difficulty += 0.05f;
            float posY = 0;
            float posX = Random.Range(-transform.localScale.x/2, transform.localScale.x/2); // задаем случайное положение астероида по оси X
            float posZ = transform.position.z;
 
            var asteroid = Instantiate(asteroids.transform.GetChild(Random.Range(0,2)), new Vector3(posX, posY, posZ), Quaternion.identity); // создаем астероид
            asteroid.GetComponent<Rigidbody>().velocity *= difficulty;
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay); // меняем время следующего появления астероида
        }
    }
}
