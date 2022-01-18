using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Velocidade = 10f;
    void Start()
    {
        this.transform.localScale = new Vector3(0.5f, 0.0f, 0.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.y < 0.3f)
        {
            this.transform.localScale += new Vector3(0, 0.025f, 0) * Time.deltaTime * 70;
        }
        
        transform.Translate(Vector3.up * Time.deltaTime * Velocidade);
        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
        
    }
}
