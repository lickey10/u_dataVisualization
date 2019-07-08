using UnityEngine;
using System.Collections;

public class instantiateTest : MonoBehaviour {

	public Transform Player;
	public Transform PreFab;
	int numberTargets = 20;
	float radius = 50f;
	
	void Start()
	{
		Vector3 position;
		int i;

		for(i = 0; i< numberTargets; i++)
		{
			position = new Vector3(Player.position.x + Random.Range(-radius,radius),0.0f,Player.position.z + Random.Range(-radius,radius));
			position.y = Terrain.activeTerrain.SampleHeight(position) + Terrain.activeTerrain.transform.position.y; 
			Transform target = (Transform)Instantiate(PreFab, position, Quaternion.identity);
			position.y = target.transform.position.y + target.transform.GetComponent<Collider>().bounds.size.y/2;
			target.position = position;
			//target.transform.position.y = target.transform.position.y + target.transform.GetComponent<Collider>().bounds.size.y/2; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateData()
	{

	}
}
