using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class acceleratorTest : MonoBehaviour {
	public float speed = 10.0F;
	public Text xValue;
	public Text yValue;
	public Text zValue;

	private int sizeFilter = 15;
	private Vector3[] filter;
	private Vector3 filterSum = Vector3.zero;
	private int posFilter = 0;
	private int qSamples = 0;

	void Update() {
		Vector3 dir = Vector3.zero;
//		dir.x = -Input.acceleration.y;
//		dir.z = Input.acceleration.x;

		dir = MovAverage(Input.acceleration.normalized);

//		dir.x = Input.acceleration.y;
//		dir.y = Input.acceleration.z;
//		dir.z = Input.acceleration.x;

		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		//dir *= Time.deltaTime;
		//transform.Translate(dir * speed);



		xValue.text = dir.x.ToString();
		yValue.text = dir.y.ToString();
		zValue.text = dir.z.ToString();
	}

	Vector3 MovAverage(Vector3 sample)
	{
		if (qSamples==0) 
			filter = new Vector3[sizeFilter];

		filterSum += sample - filter[posFilter];
		filter[posFilter++] = sample;

		if (posFilter > qSamples) 
			qSamples = posFilter;

		posFilter = posFilter % sizeFilter;
		return filterSum / qSamples;
	}
}
