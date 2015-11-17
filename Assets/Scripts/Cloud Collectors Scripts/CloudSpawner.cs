using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distanceBetweenClouds = 3f;

	private float minX, maxX;

	private float lastCloudPositionY;

	private float controlX;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;
	
	void Awake () {
		SetMinAndMaxX ();
		CreateClouds ();
	}

	void SetMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;

		Debug.Log(bounds);
		Debug.Log(minX);
		Debug.Log(maxX);
	}

	void Shuffle(GameObject[] arrayToShuffle){

		for (int i = 0; i < arrayToShuffle.Length; i++ ){
			GameObject temp = arrayToShuffle[i];
			int random = Random.Range(i, arrayToShuffle.Length);
			arrayToShuffle[i] = arrayToShuffle[random];
			arrayToShuffle[random] = temp;
		}
	}

	void CreateClouds() {

		Shuffle (clouds);

		float positionY = 0f;

		for (int i = 0; i < clouds.Length; i++) {
			Vector3 temp = clouds[i].transform.position;
			temp.y = positionY;

			temp.x = Random.Range(minX, maxX);

			if(controlX == 0) {
				temp.x = Random.Range(0.0f, maxX);
				controlX = 1;
			} else if(controlX == 1) {
				temp.x = Random.Range(0.0f, minX);
				controlX = 2;
			} else if(controlX == 2) {
				temp.x = Random.Range(1.0f, maxX);
				controlX = 3;
			} else if(controlX == 3) {
				temp.x = Random.Range(-1.0f, minX);
				controlX = 0;
			}

			lastCloudPositionY = positionY;

			clouds[i].transform.position = temp;

			positionY -= distanceBetweenClouds;

		}

	}

}
