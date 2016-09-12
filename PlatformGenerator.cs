using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	//public GameObject[] thePlatforms;
	public Transform generationPoint;

	private int distanceBetween;

	public int minDistance;
	public int maxDistance;

	private int platformWidth;
	private int platformSelector;
	private int[] platformWidths;

	public ObjectPooler[] theObjectPools;

	private int minHeight;
	private int maxHeight;
	public Transform maxHeightPoint;
	public int maxHeightChange;
	private int heightChange;

	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		platformWidths = new int[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths [i] = (int)theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
		minHeight = (int)transform.position.y;
		maxHeight = (int)maxHeightPoint.position.y;
	}

	void Update () {

		distanceBetween = Random.Range (minDistance, maxDistance);

		if (transform.position.x < generationPoint.position.x){
			
			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = (int)transform.position.y + Random.Range (-maxHeightChange, maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			}
			else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween,
			heightChange, transform.position.z);
			
			//Instantiate (/*thePlatform*/theObjectPools[platformSelector], transform.position, transform.rotation);
	
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2),
			transform.position.y, transform.position.z);
		}
	}
}
