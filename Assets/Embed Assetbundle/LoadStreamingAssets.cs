using UnityEngine;
using System.Collections;

public class LoadStreamingAssets : MonoBehaviour {
	string filePath;

	// Use this for initialization
	IEnumerator Start () {
		filePath = "file://" + System.IO.Path.Combine ( Application.streamingAssetsPath, "basic");
		print (filePath);

		using (WWW www = WWW.LoadFromCacheOrDownload (filePath, -1)) {
			yield return www;

			AssetBundle bundle = www.assetBundle;

			Instantiate (bundle.LoadAsset("Cube"));
		}

	}
}

				