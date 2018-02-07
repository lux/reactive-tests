using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tutorial {

	public class TutorialBootstrap : MonoInstaller<TutorialBootstrap> {
		public SceneContext context;

		public override void InstallBindings () {
			Container.Bind<TutorialState> ().AsSingle ();

			Container.BindInstance (GetComponent<TutorialActions> ());
		}
	}
}