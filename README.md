# Reactive Tests in Unity

Exploring [unidirectional data flow](https://www.exclamationlabs.com/blog/the-case-for-unidirectional-data-flow/) in Unity (inspired by Redux, Vuex, etc), minus [UniRx](https://github.com/neuecc/UniRx) (yet). Uses [Zenject](https://github.com/modesttree/Zenject) for dependencies.

## Examples

### Counter

This is probably the simplest example. It's simple enough that the actions class is
almost redundant save for kicking things off in `OnEnable()`.

See `Assets/Counter/Example.unity` for a demo scene.

Classes:

* [CounterBootstrap](https://github.com/lux/reactive-tests/blob/master/Assets/Counter/CounterBootstrapp.cs) - Zenject bootstrapper.
* [CounterActions](https://github.com/lux/reactive-tests/blob/master/Assets/Counter/CounterActions.cs) - Encapsulates logic in public methods called from views.
* [CounterState](https://github.com/lux/reactive-tests/blob/master/Assets/Counter/CounterState.cs) - Encapsulates local state changes and fires change events.
* [CounterView](https://github.com/lux/reactive-tests/blob/master/Assets/Counter/CounterView.cs) - Updates the UI on change events from user and state.

### Tutorial

This example syncs the state to `PlayerPrefs`, and provides some input validation at the
state layer.

See `Assets/Tutorial/Example.unity` for a demo scene.

Classes:

* [TutorialBootstrap](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/TutorialBootstrapp.cs) - Zenject bootstrapper.
* [TutorialActions](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/TutorialActions.cs) - Encapsulates logic in public methods called from views.
* [TutorialState](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/TutorialState.cs) - Encapsulates local state changes and fires change events.
* [TutorialView](https://github.com/lux/reactive-tests/blob/master/Assets/Tutorial/TutorialView.cs) - Updates the UI on change events from user and state.
