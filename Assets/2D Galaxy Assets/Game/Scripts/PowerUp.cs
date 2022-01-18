using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float Velocidade = 1f;
    [SerializeField]
    private int powerID = 0;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisao " + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                if(powerID == 0)
                {
                    player.LaserTriploAtivar();
                }
                else if(powerID == 1)
                {
                    player.VelocidadeUP();
                }
                else if(powerID == 2)
                {
                    player.escudoAtivar();
                }
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Velocidade);
        
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroiPowerInic()
    {
        Destroy(this.gameObject);
    }
}
