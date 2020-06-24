using UnityEngine;
using System.Collections;

public class KeyBoardController : MonoBehaviour {
    private static KeyBoardController instance_;
    int mKeyPressedCount = 0;
    public static KeyBoardController Instance {
        get {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<KeyBoardController>();
            return instance_;
        }
    }
    public CharacterController cController;
    public MouseLook mLook0;
    public MouseLook mLook1;
    public GameObject panel;
    public GameObject[] fluids;
    private ScenarioController scenarioController;
    bool mustShow =false;
    private Vector3 moveDirection = Vector3.zero;
    private float speed = 0;


    void Start () {
        scenarioController = GameObject.FindObjectOfType<ScenarioController>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        cController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.M)&&mKeyPressedCount<20)
        {
            mKeyPressedCount++;
        }
        if (mKeyPressedCount > 10 && mKeyPressedCount<100)
        {
            mKeyPressedCount = 1000;
            foreach (GameObject go in fluids)
                go.SetActive(true);
            //GameObject.FindObjectOfType<ScenarioController>().scenario.currentPosition = 623;
        }
        
        if (Input.GetKeyDown(KeyCode.Tab) && DialogController.Instance==null)
        {
            mustShow = !mustShow;
            panel.SetActive(mustShow);
            cController.enabled = !mustShow;
            mLook0.enabled = !mustShow;
            mLook1.enabled = !mustShow;
            Cursor.visible = mustShow;
        }
    }

    public void SetMoving(bool flag)
    {
        cController.enabled = flag;
        mLook0.enabled = flag;
        mLook1.enabled = flag;
        Cursor.visible = !flag;
    }

    public void OnTriggerEnter(Collider coll)
    {
        scenarioController.interactingObject = coll.transform;
    }
}
