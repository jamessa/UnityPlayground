#Coroutine
A coroutine is like a function that has the ability to pause execution and return control to Unity but then to continue where it left off on the following frame.

It runs on main thread and work with non MonoBehaviour classes. 

#Coroutine & yield

Corountine is Unity's solution to asynchrounous operations. However, there's an mystery `yield return null` vs `yield return WaitForEndOfFrame`.

They'r triggered at different time. http://answers.unity3d.com/questions/755196/yield-return-null-vs-yield-return-waitforendoffram.html

#Coroutine vs Monobehavior

http://answers.unity3d.com/questions/161084/coroutine-without-monobehaviour.html
http://answers.unity3d.com/questions/932786/coroutine-1.html

#Coroutines

Normal coroutine updates are run after the Update function returns. A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes. Different uses of Coroutines:

* `yield` The coroutine will continue after all Update functions have been called on the next frame.
* `yield WaitForSeconds` Continue after a specified time delay, after all Update functions have been called for the frame
* `yield WaitForFixedUpdate` Continue after all FixedUpdate has been called on all scripts
* `yield WWW` Continue after a WWW download has completed.
* `yield StartCoroutine` Chains the coroutine, and will wait for the MyFunc coroutine to complete first.

From http://docs.unity3d.com/Manual/ExecutionOrder.html