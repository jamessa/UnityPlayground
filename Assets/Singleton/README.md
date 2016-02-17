#Singletons

Two Singletons are demostrated in the example along with their generic type sibling.

##Pure C# 


A formal discussion of Singleton is [here](https://msdn.microsoft.com/en-us/library/ff650316.aspx).

Creating a singleton class is just a few lines of code, and with the difficulty of making a generic singleton I always write [those lines of code](http://stackoverflow.com/questions/380755/a-generic-singleton). 

##Unity way

Unity provides a safer way to create Singleton. A gameobject will be created to wrap up the Singleton. So that you'll see a Singleton GameObject in the scene.

http://wiki.unity3d.com/index.php/Singleton

## Conclusion

Use Unity generics way when you absolutely need Monobehaviour. Otherwise, use Pure C# without Generics is recommanded.