using UnityEngine;
using System.Collections;
using GDGeek;
using System;

public class PoliceManager : MonoBehaviour {

    public PoliceDriver[] _drivers;
    public VoxelPool _garage;
    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < _drivers.Length; ++i) {
            VoxelPoolObject obj = _garage.create();
            //obj.gameObject.SetActive(true);
            _drivers[i]._car = obj.GetComponent<Car>();
            _drivers[i].gameObject.SetActive (true);
        }
        //_driver._car.transform.localPosition = new Vector3();
    }

    public void where(int n)
    {
        for (int i = 0; i < _drivers.Length; ++i)
        {
            _drivers[i].where(n);
        }
    }
}
