using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool tiroTriplo = false;
    public bool velocidadeUp = false;
    public bool escudoUp = false;
    private AudioSource powerUpAudio;

    [SerializeField]
    private GameObject escudoGameObj;
    [SerializeField]
    private GameObject turbina;
    [SerializeField]
    private GameObject dano_motor;
    [SerializeField]
    private float Velocidade = 7f;
    [SerializeField]
    private GameObject Laser;
    [SerializeField]
    private float tempoAtirar = 0.13f;
    private float verifAtirar;
    [SerializeField]
    private int vidas = 3;
    [SerializeField]
    private GameObject explosao;

    private UIManager uimanagerObj;
    private GameManager gameManagr;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        powerUpAudio = GetComponent<AudioSource>();
        uimanagerObj = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManagr = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(uimanagerObj != null)
        {
            uimanagerObj.UpdateVida(vidas);
        }
    }

    void Update()
    {
        Controlador();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > verifAtirar)
        {
            Atirar();
            verifAtirar = Time.time + tempoAtirar;
        }
    }
    private void Controlador()
    {

        if(velocidadeUp == true)
        {
            Velocidade = 13f;
        }
        else
        {
            Velocidade = 7f;
        }

        float eixoX = Velocidade * Input.GetAxis("Horizontal");
        float eixoY = Velocidade * Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * eixoX * Time.deltaTime);
        transform.Translate(Vector3.up * eixoY * Time.deltaTime);

        //limite horizontal
        if (transform.position.x > 8.25f)
        {
            transform.position = new Vector3(8.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.25f)
        {
            transform.position = new Vector3(-8.25f, transform.position.y, 0);
        }

        //limite vertical
        if (transform.position.y > 4.25f)
        {
            transform.position = new Vector3(transform.position.x, 4.25f, 0);
        }
        else if (transform.position.y < -4.25f)
        {
            transform.position = new Vector3(transform.position.x, -4.25f, 0);
        }
    }
    private void Atirar()
    {
        if(tiroTriplo == true)
        {
            Instantiate(Laser, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
            Instantiate(Laser, transform.position + new Vector3(0.55f, -0.45f, 0), transform.rotation);
            Instantiate(Laser, transform.position + new Vector3(-0.55f, -0.45f, 0), transform.rotation);
        }
        else
        {
            Instantiate(Laser, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        }
    }

    public void Dano()
    {
        if(escudoUp == true)
        {
            escudoUp = false;
            escudoGameObj.SetActive(false);
            return;
        }

        vidas--;
        uimanagerObj.UpdateVida(vidas);
        if (vidas < 1)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            gameManagr.GameOver = true;
            Destroy(this.gameObject);
        }
        if (vidas == 1)
        {
            dano_motor.SetActive(true);
        }
    }
    public void escudoAtivar()
    {
        escudoUp = true;
        powerUpAudio.Play();
        escudoGameObj.SetActive(true);
    }

    public void LaserTriploAtivar()
    {
        tiroTriplo = true;
        powerUpAudio.Play();
        StartCoroutine(LaserTriploDesativar());
    }

    public void VelocidadeUP()
    {
        velocidadeUp = true;
        turbina.SetActive(true);
        powerUpAudio.Play();
        StartCoroutine(VelocidadeUPDesativar());
    }

    public IEnumerator LaserTriploDesativar()
    {
        yield return new WaitForSeconds(5);
        tiroTriplo = false;
    }

    public IEnumerator VelocidadeUPDesativar()
    {
        yield return new WaitForSeconds(5);
        turbina.SetActive(false);
        velocidadeUp = false;
    }
}