#Delegates and Events

C# events is a good way for decoupling. Here's an update demo from [Unity 3D tutorial: Events](https://unity3d.com/learn/tutorials/modules/intermediate/scripting/events).

A more in depth explanation by 
[Brian MacDonald, Mastering C# 3.0, Chapter 17. Delegates and Events](https://msdn.microsoft.com/en-us/library/orm-9780596521066-01-17.aspx?f=255&MSPPError=-2147217396).

In [Event Performance: C# vs. UnityEvent](http://jacksondunstan.com/articles/3335), Jack Sondunstan says that 

> In conclusion, UnityEvent creates less garbage than C# events if you add more than two listeners to it, but creates more garbage otherwise. It creates garbage when dispatched (Update: the first time) where C# events do not. And it’s at least twice as slow as C# events. There doesn’t seem to be a compelling case to use it, at least by these metrics.