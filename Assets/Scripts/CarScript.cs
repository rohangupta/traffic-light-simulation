using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

        private Rigidbody car;
        public int move = 1;
        public float speed = 5.0f;

	void Start () {
        
                car = GetComponent<Rigidbody>();
                //car.interpolation = RigidbodyInterpolation.Interpolate;       Some bug in Unity 5.6.1 which gives error when interpolation is on, hence it's off.
                car.constraints = RigidbodyConstraints.FreezePositionY;
                car.constraints = RigidbodyConstraints.FreezePositionZ;
        }
	
	void FixedUpdate () {
          
                if(move == 1) {
                        
                        car.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);
                }
                //Debug.Log(Time.deltaTime);
        }
}
