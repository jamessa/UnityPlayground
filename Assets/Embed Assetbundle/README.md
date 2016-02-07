#Make an embedded asset bundle
The basic idea is to put *default* asset bundle into `StreamingAsset` folder to make bundle loading all the same. 

To try it out

1. [Assets]->[Build AssetBundles]
2. `StreamingAssets` should have a bundles. Sometimes you need to restart Unity to make it appear.
3. Choose `LoadFromStreamingAssets` scene, a blue box should appear.

In fact, the StreamingAssets will be loaded into `Data/raw` under iOS and build alone with iOS build. I think this it the prefered way to handle default assets.

#Reference
* [Deploying asset bundles with your game as StreamingAssets](http://docs.unity3d.com/Manual/AssetBundleCompression.html)

* [Unity embed bundleAsset](http://answers.unity3d.com/questions/861008/unity-embed-bundleasset.html)

* [Including bundleassets into a build](
http://answers.unity3d.com/questions/638586/including-bundleassets-into-a-build.html)

