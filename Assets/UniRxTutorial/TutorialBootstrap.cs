using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UniRxTutorial {

	public class TutorialBootstrap : MonoInstaller<TutorialBootstrap> {

		public override void InstallBindings () {
			Container.BindInstance (new TutorialState ());

			Container.BindInstance (GetComponent<TutorialStorage> ());
		}
	}
}