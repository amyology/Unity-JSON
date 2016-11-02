using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;

public class jsonScript : MonoBehaviour {

	public string url;
	public GameObject image;

	// Use this for initialization
	void Start () {
//		StartCoroutine (loadJson ());
//		StartCoroutine (postScore ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void post(){
		StartCoroutine (postScore ());
	}

	IEnumerator postScore() {
		WWWForm form = new WWWForm ();
		form.AddField("url", url);
		WWW postRequest = new WWW("http://localhost:3000/videos", form);
		yield return postRequest;
	}

	IEnumerator loadJson() {
		using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/videos.json"))
		{
			yield return request.Send();

			if (request.isError) {
				Debug.Log(request.error);
			} else {
				JSONObject json = new JSONObject(request.downloadHandler.text);
				url = json [2] ["url"].ToString ();
				url = url.Substring (1, url.Length - 2);

				WWW www = new WWW(url);
				yield return www;
				Renderer renderer = image.GetComponent<Renderer>();
				renderer.material.mainTexture = www.texture;
			}
		}
	}
}