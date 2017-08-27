using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour {
        
        public GameObject tlight;

        private Transform carTransform;
        private float spawnX = 15.0f;
        private int tlightsonscreen = 2;
        private float safeZone = 5.0f;

        Vector3 spawnPosition;

        private List<GameObject> activeTLights;

	void Start () {
                carTransform = GameObject.FindGameObjectWithTag("Car").transform;
                activeTLights = new List<GameObject>();

                spawnPosition = new Vector3(spawnX, 0.0f, 0.8f);

                for(int i = 0; i < tlightsonscreen; i++) {
                        SpawnTLight();
                }
        }
	
	void Update () {
		if((carTransform.position.x - safeZone) > activeTLights[0].transform.position.x) {
                        SpawnTLight();
                        DeleteTLight();
                }
	}

        void SpawnTLight() {
                GameObject gotf;
                gotf = Instantiate(tlight) as GameObject;
                gotf.transform.SetParent(transform);
                gotf.transform.position = spawnPosition;
                gotf.AddComponent<TrafficLightScript>();
                spawnX = spawnX + Random.Range(15.0f, 30.0f);
                spawnPosition = new Vector3(spawnX, 0.0f, 0.8f);
                activeTLights.Add(gotf);
        }

        void DeleteTLight() {
                Destroy(activeTLights[0]);
                activeTLights.RemoveAt(0);
        }
}
