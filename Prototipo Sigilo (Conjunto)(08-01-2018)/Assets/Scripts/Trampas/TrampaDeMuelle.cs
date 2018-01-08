using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaDeMuelle : MonoBehaviour {

    public Rigidbody rb;
    public GameObject Enemy;
    public GameObject Springtrap;
    public float Speed = 10;

	// Use this for initialization
	void Start () {
        
        //StartCoroutine(MovMuelle());

    }

    /*IEnumerator MovMuelle()
    {
        yield return new WaitForSeconds(3);
        Muelle.transform.Translate(new Vector3(-2,2,0) * Time.deltaTime);
        Muelle.transform.Rotate(new Vector3(0,0,90) * Time.deltaTime);
    }*/

	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
        }
    }
}
