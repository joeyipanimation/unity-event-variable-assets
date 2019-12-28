# unity-event-variable-assets
Assets-based events and variables ensures system/prefab integrity. This helps you create robust fully standalone prefabs & modules. Say goodbye to re-creating the scene in order to unit test a prefab!

Based on the modular setup explained [here](https://unity3d.com/how-to/architect-with-scriptable-objects).

# Author
Created and distributed by Joe Yip (2018). Please direct comments, bugs, and requests to  joeyipanimation@gmail.com. 

# Release Notes

### Version 0.5

* Serializing scriptable asset version, inspector display, and version upgrade button
* Improved callstack view to show full stack and clear-stack button

### Version 0.4
* Fixed string formatter null ref

### Version 0.3
* Added stringFormat version of genericEventData
* Added RuntimeValue to GenericVariable, to mirror Unity's behavior

### Version 0.2
* Added "opposite response" to bool and float event listeners
* Added event call-stack tracer to help debugging
* Added string format and listener
