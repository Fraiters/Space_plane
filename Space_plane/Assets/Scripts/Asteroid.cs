using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody asteroid;
    public float minSpeed, maxSpeed;
    private float speed;
    public float rotation; // коэффициент поворота
    public GameObject explosionAsteroid; // взрыв астероида
    public GameObject explosionPlayer; // взрыв корабля
    /*private float scale;*/

    // Start is called before the first frame update
    private void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation; // придаем вращение астероиду
        speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);
        /*scale = Random.Range(0.5f, 1.5f);
        asteroid.transform.localScale *= scale;*/
    }

    // вызывается при столкновении с другим объектом (переменная other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "GameBoundary")
        {
            return;
        }

        Destroy(gameObject); // уничтожаем астероид
        Destroy(other.gameObject); // уничтожаем объект, с которым сталкивается астероид

        Instantiate(explosionAsteroid, transform.position, Quaternion.identity); // добавляем взрыв астероида

        
        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, Quaternion.identity); // добавляем взрыв корабля при столкновении с астероидом
        }

        if (other.tag == "SideLeftLazerShot" || other.tag == "SideRightLazerShot" || other.tag == "LazerShot")
        {
            GameControllerScript.instance.score += 5;// увеличение кол-во очков за попадание
        }
    }
}
