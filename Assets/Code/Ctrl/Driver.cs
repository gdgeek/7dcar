using UnityEngine;
using System.Collections;
using System;
using GDGeek;

public class Driver : MonoBehaviour {
    public RoadManager _roadManager;
    public Car _car;
    public Camera _camera;
    private bool alive_ = true;
    private FSM fsm_ = new FSM(); 
	// Use this for initialization
	void Start () {
       fsm_.addState("normal", getNormalState());
        fsm_.addState("turn", getTurnState());
        fsm_.init("normal");

    }
    private State getNormalState()
    {
        StateWithEventMap state = new StateWithEventMap();
       // state.addAction("left", )
        return state;
    }


    private State getTurnState()
    {
        State state = new State();
        return state;
    }
    // Update is called once per frame
    void Update () {
        if (!alive_) {
            return;
        }
        _car.transform.localPosition += new Vector3(0, 0, 300 * Time.deltaTime);
        _roadManager.driver(_car.transform.localPosition);
    }

    public void traffic()
    {
    //    Debug.LogError("!!!");
        alive_ = false;
        if (_car._emitter != null) {
            _car._mesh.enabled = false;
            _car._emitter.enabled = true;
        }
        
        // boom!!
        //close car
        //  _car.gameObject.SetActive(false);

    }


    // Subscribe to events
    void OnEnable()
    {
        EasyTouch.On_TouchStart += On_SimpleTap;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    // Simple tap
    private void On_SimpleTap(Gesture gesture)
    {
        if (!alive_)
        {
            return;
        }

        Vector3 vp = _camera.ScreenToViewportPoint(new Vector3(gesture.position.x, gesture.position.y, 0.0f));
        Debug.LogWarning("!!"+ vp);
        if (vp.x < 0.4f) {
            _car.transform.localPosition = new Vector3(_car.transform.localPosition.x-18, _car.transform.localPosition.y, _car.transform.localPosition.z);
            Debug.Log("left");
        } else if(vp.x > 0.6f)
        {
            _car.transform.localPosition = new Vector3(_car.transform.localPosition.x +18, _car.transform.localPosition.y, _car.transform.localPosition.z);
            Debug.Log("right");
        }
        if (_car.transform.localPosition.x < -18) {
            _car.transform.localPosition = new Vector3(- 18, _car.transform.localPosition.y, _car.transform.localPosition.z);

        }else if (_car.transform.localPosition.x > 18)
        {
            _car.transform.localPosition = new Vector3(18, _car.transform.localPosition.y, _car.transform.localPosition.z);

        }
    }
}
