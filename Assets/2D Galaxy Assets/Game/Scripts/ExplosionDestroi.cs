using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroi());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Destroi()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
