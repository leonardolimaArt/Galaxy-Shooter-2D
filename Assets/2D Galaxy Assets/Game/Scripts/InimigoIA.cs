using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public bool Asteroid = false;
    [SerializeField]
    private float velocidade = 2f;

    [SerializeField]
    private GameObject explosao;

    private UIManager uimanagerOBJ;
    void Start()
    {
        uimanagerOBJ = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        if(transform.position.y < -7)
        {
          Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser") 
        {
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(other.gameObject);
            if (Asteroid == false)
            {
                uimanagerOBJ.UpdateScore();
            }
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                if(player.escudoUp == true)
                {
                    uimanagerOBJ.UpdateScore();
                }
                player.Dano();
            }
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
