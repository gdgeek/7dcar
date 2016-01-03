using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RoadManager : MonoBehaviour {

    public Road _road;
    public int _n;
    public PoliceManager _policeManager;

    internal void driver(Vector3 localPosition)
    {
        int n = (int)(localPosition.z / 64);
        if(_n != n) {
            _road.transform.localPosition = new Vector3(_road.transform.localPosition.x, _road.transform.localPosition.y, _n * 64.0f);
            _policeManager.where(n);
            _n = n;
        }
    }

  
  
}
