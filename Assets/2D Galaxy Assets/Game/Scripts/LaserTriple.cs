using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriple : MonoBehaviour
{
    public float Velocidade = 10f;
    public GameObject Laser_0;
    public GameObject Laser_1;
    public GameObject Laser_2;

    void Start()
    {
        Laser_0.transform.localScale = new Vector3(0.5f, 0.0f, 0.5f);
        Laser_1.transform.localScale = new Vector3(0.5f, 0.0f, 0.5f);
        Laser_2.transform.localScale = new Vector3(0.5f, 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Laser_0.transform.localScale.y < 0.3f)
        {
            Laser_0.transform.localScale += new Vector3(0, 0.025f, 0) * Time.deltaTime * 70;
            Laser_1.transform.localScale += new Vector3(0, 0.025f, 0) * Time.deltaTime * 70;
            Laser_2.transform.localScale += new Vector3(0, 0.025f, 0) * Time.deltaTime * 70;
        }

        transform.Translate(Vector3.up * Time.deltaTime * Velocidade);
        if (transform.position.y > 7)
        {
            Destroy(this.gameObject);
        }
    }
}
