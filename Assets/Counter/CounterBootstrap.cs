using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Counter {

	public class CounterBootstrap : MonoInstaller<CounterBootstrap> {
		public SceneContext context;

		public override void InstallBindings () {
			Container.Bind<CounterState> ().AsSingle ();

			Container.BindInstance (GetComponent<CounterActions> ());
		}
	}
}