using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightScript : MonoBehaviour {

        public GameObject cargo;
        GameObject rlight;
        GameObject glight;
       
        public int flag, change = 0;

	void Start () {
                cargo = GameObject.FindGameObjectWithTag("Car");

                rlight = gameObject.transform.GetChild(0).gameObject;
                glight = gameObject.transform.GetChild(1).gameObject;

                rlight.SetActive(false);
                glight.SetActive(false);

                flag = Random.Range(0,2);
                if (flag == 0)
                        StartCoroutine(GreenLight());
                else
                        StartCoroutine(RedLight());
        }
	
	void Update () {
	        if(flag == 1) {
                        if((cargo.transform.position.x > (gameObject.transform.position.x - 1.0f)) && (cargo.transform.position.x < gameObject.transform.position.x)) {
                                cargo.GetComponent<CarScript>().move = 0;
                        }
                }

                if(change == 1) {
                        if (flag == 0) {
                                flag = 1;
                                change = 0;
                                StartCoroutine(RedLight());
                        }
                                
                        else {
                                flag = 0;
                                change = 0;
                                cargo.GetComponent<CarScript>().move = 1;
                                StartCoroutine(GreenLight());
                        }               
                }
	}

        IEnumerator GreenLight() {
                //Debug.Log("Green Light");
                glight.SetActive(true);
                yield return new WaitForSeconds(20);
                glight.SetActive(false);
                change = 1;
        }

        IEnumerator RedLight()
        {
                //Debug.Log("Red Light");
                rlight.SetActive(true);
                yield return new WaitForSeconds(20);
                rlight.SetActive(false);
                change = 1;
        }
}
