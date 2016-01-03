using UnityEngine;
using System.Collections;

public class Traffic : MonoBehaviour {

    public Driver _driver;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        _driver.traffic();
       // Debug.Log(other.name);
    }
}
