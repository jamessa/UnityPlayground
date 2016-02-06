using UnityEngine;
using UnityEditor;

public class CreateAssetBundles
{
	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
		Debug.Log( "Saving to " + Application.streamingAssetsPath );
		BuildPipeline.BuildAssetBundles ( Application.streamingAssetsPath );
	}
}