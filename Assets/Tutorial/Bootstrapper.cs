using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tutorial {

	public class Bootstrapper : MonoInstaller<Bootstrapper> {
		public SceneContext context;

		private Actions _actions;
		private State _state;

		public override void InstallBindings () {
			Container.Bind<State> ().AsSingle ();

			Container.BindInstance (GetComponent<Actions> ());
		}
	}
}