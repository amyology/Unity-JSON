using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InputScript : MonoBehaviour {

	public string username;
	InputField input;

	// Use this for initialization
	void Start () {
		input = gameObject.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Submit(){
		username = input.text;
		StartCoroutine (postScore ());
	}

	IEnumerator postScore() {
		WWWForm form = new WWWForm ();
		form.AddField("url", username);
		WWW postRequest = new WWW("http://localhost:3000/videos", form);
		yield return postRequest;
	}
}
