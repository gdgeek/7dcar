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
        fsm_.addState("left", getLeftState());
        fsm_.addState("right", getRightState());
        fsm_.init("normal");

    }
    private State getNormalState()
    {
        StateWithEventMap state = new StateWithEventMap();
        state.addAction("left", delegate
        {
				Debug.Log(_car.transform.localPosition.x);
            if (_car.transform.localPosition.x > -18) {
                return "left";
            }
            return "";
        });
        state.addAction("right", delegate {

            if (_car.transform.localPosition.x < 18)
            {
                return "right";
            }
            return "";
        });
        return state;
    }

    private State getRightState() {
        StateWithEventMap state = TaskState.Create(delegate
        {
            Task task = new TweenTask(delegate
            {
                return TweenLocalPosition.Begin(this._car.gameObject, 0.3f, new Vector3(_car.transform.localPosition.x + 18, _car.transform.localPosition.y, _car.transform.localPosition.z + 300 * 0.3f));
            });
            return task;
        }, this.fsm_, "normal");
        return state;
    }
    private State getLeftState()
    {
        StateWithEventMap state = TaskState.Create(delegate
        {
            Task task = new TweenTask(delegate
            {
				Debug.Log("!!!!!!!!!!!!!!!!");
                return TweenLocalPosition.Begin(this._car.gameObject, 0.3f, new Vector3(_car.transform.localPosition.x-18, _car.transform.localPosition.y, _car.transform.localPosition.z +300*0.3f));
            });
            return task;
        }, this.fsm_, "normal");
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

        if (vp.x < 0.4f) {
          //  _car.transform.localPosition = new Vector3(_car.transform.localPosition.x-18, _car.transform.localPosition.y, _car.transform.localPosition.z);
            Debug.Log("left");
            this.fsm_.post("left");
        } else if(vp.x > 0.6f)
        {
         //   _car.transform.localPosition = new Vector3(_car.transform.localPosition.x +18, _car.transform.localPosition.y, _car.transform.localPosition.z);
            Debug.Log("right");
            this.fsm_.post("right");
        }
        /*
        if (_car.transform.localPosition.x < -18) {
            _car.transform.localPosition = new Vector3(- 18, _car.transform.localPosition.y, _car.transform.localPosition.z);

        }else if (_car.transform.localPosition.x > 18)
        {
            _car.transform.localPosition = new Vector3(18, _car.transform.localPosition.y, _car.transform.localPosition.z);

        }*/
    }
}
