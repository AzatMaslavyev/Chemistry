using UnityEngine;
using System.Collections;

public class L3 : MonoBehaviour {
	private bool isOpen=true;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animation>()) {
			if (Input.GetKey (KeyCode.X)){
				GetComponent<Animation>().Play("Armature|Rot");
			}
			if (Input.GetKey (KeyCode.C)){
				//if(isOpen){
				//	isOpen=false;
					GetComponent<Animation>().Play("Armature|Clouse");

				//}else{
					//isOpen=true;
					


				//}

			}

			if (Input.GetKey (KeyCode.V)){
				GetComponent<Animation>().Play("Armature|Open");
				//animation.Play("Armature|Open");
			}
		}
	}
}
