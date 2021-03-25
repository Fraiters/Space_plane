using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public float speed;
    public GameObject lazer;
    public GameObject explosionPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }


    private void OnTriggerEnter(Collider other)
    {   
        
        
        if (other.tag == "Player" || other.tag == "Asteroid")
        {
            Destroy(gameObject); // уничтожаем вражеский лазер
            Destroy(other.gameObject); // уничтожаем объект, в который попадает лазер
            Instantiate(explosionPlayer, other.transform.position, Quaternion.identity); // добавляем взрыв корабля при столкновении с лазером
            
        }
    }
}
