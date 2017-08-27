using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

        public GameObject road;
        
        private Transform carTransform;
        private float spawnX = 0.0f;
        private float tileLength = 10.0f;
        private int tilesOnScreen = 5;
        private float safeZone = 15.0f;

        private List<GameObject> activeTiles;

	void Start () {
                carTransform = GameObject.FindGameObjectWithTag("Car").transform;
                activeTiles = new List<GameObject>();

                for (int i = 0; i < tilesOnScreen; i++) {
                        SpawnTile();
                }        
	}
	
	void Update () {
                if ((carTransform.position.x - safeZone) > (spawnX - tilesOnScreen * tileLength)) {
                        SpawnTile ();
                        DeleteTile();
                }
                        
	}

        void SpawnTile() {
                GameObject go;
                go = Instantiate(road) as GameObject;
                go.transform.SetParent(transform);
                go.transform.position = Vector3.right * spawnX;
                spawnX += tileLength;
                activeTiles.Add(go);
        }

        void DeleteTile() {
                Destroy(activeTiles[0]);
                activeTiles.RemoveAt(0);        
        }
}
