using UnityEngine;
using System.Collections;
using System;

public class PoliceDriver : MonoBehaviour {

    // Use this for initialization

    public Car _car;
    public float _speed = 50.0f;
    public Vector3[] _positions;
    private int _n = 0;
	void Start () {
        setup();
        _car.gameObject.SetActive(true);

    }
    void setup() {
        _car.transform.localPosition = _positions[UnityEngine.Random.Range(0, _positions.Length)] + new Vector3(0, 0, _n * 64);
    }
    // Update is called once per frame
    void Update () {

        _car.transform.localPosition += new Vector3(0, 0, _speed * Time.deltaTime);
    }

    public void where(int n)
    {
        _n = n;
        if ((int)(_car.transform.localPosition.z / 64.0f) < (n-1)) {
            setup();
        }
    }
}
