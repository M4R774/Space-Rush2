using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


[System.Serializable]
public class LineVector
{
	public Vector3 l1e1;
	public Vector3 l1e2;
	
	public Vector3 l2e1;
	public Vector3 l2e2;
	public Vector3 l2e3;
	
	public Vector3 l3e1;
	public Vector3 l3e2;
	public Vector3 l3e3; 
}

public class MapController : MonoBehaviour {
	
	public float speed = 0.01f;
	public GameObject encouter;

	public LineVector vectors;

	private int height = Screen.height;
	private int width = Screen.width;

	public Color c1 = Color.red;

	// Use this for initialization
	void Awake () {
		
		GameObject line1 = new GameObject();
		LineRenderer lineRenderer1 = line1.AddComponent<LineRenderer> ();
		GameObject line2 = new GameObject ();
		LineRenderer lineRenderer2 = line2.AddComponent<LineRenderer> ();
		GameObject line3 = new GameObject ();
		LineRenderer lineRenderer3 = line3.AddComponent<LineRenderer> ();

		lineRenderer1.SetColors (c1, c1);
		lineRenderer2.SetColors (c1, c1);
		lineRenderer3.SetColors (c1, c1);

		lineRenderer1.SetWidth (0.05f, 0.05f);
		lineRenderer2.SetWidth (0.05f, 0.05f);
		lineRenderer3.SetWidth (0.05f, 0.05f);

		lineRenderer2.SetVertexCount (3);
		lineRenderer3.SetVertexCount (3);


		lineRenderer1.SetPosition (0, vectors.l1e1);
		lineRenderer1.SetPosition (1, vectors.l1e2);

		lineRenderer2.SetPosition (0, vectors.l2e1);
		lineRenderer2.SetPosition (1, vectors.l2e2);
		lineRenderer2.SetPosition (2, vectors.l2e3);

		lineRenderer3.SetPosition (0, vectors.l3e1);
		lineRenderer3.SetPosition (1, vectors.l3e2);
		lineRenderer3.SetPosition (2, vectors.l3e3);
		
		Instantiate (encouter,new Vector3(1.8f, 2f, 0f), Quaternion.identity);
		Instantiate (encouter,new Vector3(-1.8f, 2f, 0f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {

	}
}