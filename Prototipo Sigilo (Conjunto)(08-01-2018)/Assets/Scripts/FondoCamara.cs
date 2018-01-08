using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoCamara : MonoBehaviour {


    public Transform Fondo;

    private bool Whichone = true;

    public Transform camara;

    private float alturaActual = 15;


	// Update is called once per frame
	void Update () {
		
        if (alturaActual < camara.position.y)
        {
            if (Whichone)
                Fondo.localPosition = new Vector3(0, Fondo.localPosition.y + 30, 10);

            alturaActual += 15;
            Whichone = !Whichone;
        }


        if (alturaActual > camara.position.y + 15)
        {
            if (Whichone)
                Fondo.localPosition = new Vector3(0, Fondo.localPosition.y - 30, 10);

            alturaActual -= 15;
            Whichone = !Whichone;
        }
	}
}
