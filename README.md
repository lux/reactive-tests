# Reactive Tests in Unity

Exploring unidirectional data flow in Unity (inspired by Redux, Vuex, etc), minus [UniRx](https://github.com/neuecc/UniRx) (yet). Uses [Zenject](https://github.com/modesttree/Zenject) for dependencies.

See `Assets/Tutorial` for sample code and `Assets/Tutorial/Scenes/Example.unity` for a working example scene. Here's a quick summary of classes:

* [Bootstrapper](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/Bootstrapper.cs) - Zenject bootstrapper.
* [Actions](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/Actions.cs) - Actions that encapsulate logic, which are called from View.
* [State](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/State.cs) - Encapsulates local state changes and fires change events.
* [View](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/View.cs) - Updates the UI when events are fired from State.
