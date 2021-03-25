using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLazer : MonoBehaviour
{
    public float speed;
    public GameObject lazer;
    // Start is called before the first frame update
    private void Start()
    {
        if (lazer.tag == "SideLeftLazerShot")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-speed/2, 0, speed/2);
        }

        if (lazer.tag == "SideRightLazerShot")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed/2, 0, speed/2);
        }

        if (lazer.tag == "LazerShot")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        }
    }

}
