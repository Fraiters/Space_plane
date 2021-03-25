using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public Transform asteroids;
    public float minDelay, maxDelay; // задержка между запусками
    private float nextLaunchTime; // время следующего запуска

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {   
            float posY = 0;
            float posX = Random.Range(-transform.localScale.x/2, transform.localScale.x/2); // задаем случайное положение астероида по оси X
            float posZ = transform.position.z;
 
            Instantiate(asteroids.transform.GetChild(Random.Range(0,2)), new Vector3(posX, posY, posZ), Quaternion.identity); // создаем астероид
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay); // меняем время следующего появления астероида
        }
    }
}
