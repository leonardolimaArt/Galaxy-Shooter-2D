using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("virar_esquer", true);
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("virar_direita", true);
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("virar_direita", false);

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("virar_esquer", false);

        }
    }
}
