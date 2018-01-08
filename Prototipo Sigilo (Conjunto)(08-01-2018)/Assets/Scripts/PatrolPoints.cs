using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour {

    public Transform[] patrolpoints;
	int puntoActual;
    public float velocidadMovimiento = 0.5f;
    public float tiempoParado = 2f;
    public float alcanceVision = 3f;
    public float fuerza;
    public bool dead;


    Animator anim;

  
    

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("Patrol");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, alcanceVision);
        if (hit.collider != null && hit.collider.tag == "Player")
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * fuerza + (hit.collider.transform.position - transform.position) * fuerza);
    }


    IEnumerator Patrol()
    {
        while (true)
        {

            if (transform.position.x == patrolpoints[puntoActual].position.x && !GetComponent<DestroyByContact>().muerto)
            {
                puntoActual++;
                anim.SetBool("Andar", false);
                yield return new WaitForSeconds(tiempoParado);
                anim.SetBool("Andar", true);


            }

            //para resetear el movimiento, y que se vuelva a dirigir al siguiente punto
            if (puntoActual >= patrolpoints.Length)
            {
                puntoActual = 0;
            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[puntoActual].position.x, transform.position.y), velocidadMovimiento);

            if (transform.position.x > patrolpoints[puntoActual].position.x)
            {
                transform.localScale = new Vector3(0.28f, 0.28f, 0.28f);
            }
                
            else if (transform.position.x < patrolpoints[puntoActual].position.x)
            {
                transform.localScale = new Vector3(-0.28f, 0.28f, 0.28f);
            }
            
                
            



            yield return null;


        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
            Destroy(this.gameObject, 0.1f);
    }

   /* void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * sight);

    } */


}

