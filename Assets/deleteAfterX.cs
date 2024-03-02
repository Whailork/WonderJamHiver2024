using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdleteAfterX : MonoBehaviour
{

    public float deleteAfter = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteAfterX());
    }

    IEnumerator DeleteAfterX ()
    {

        yield return new WaitForSeconds(deleteAfter);
        Destroy(gameObject);

    }
    
}