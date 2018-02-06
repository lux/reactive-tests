# Reactive Tests

Exploring unidirectional data flow in Unity (inspired by Redux, Vuex, etc), minus UniRx. Uses Zenject for dependencies.

See `Assets/Tutorial` for sample code and `Assets/Tutorial/Scenes/Example.unity` for a working example scene.

* Bootstrapper - Zenject bootstrapper.
* Actions - Actions that encapsulate logic, which are called from View.
* State - Encapsulates local state changes and fires change events.
* View - Updates the UI when events are fired from State.

