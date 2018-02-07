using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UniRxCounter {

	public class CounterBootstrap : MonoInstaller<CounterBootstrap> {
		public override void InstallBindings () {
			Container.BindInstance (GetComponent<CounterState> ());
		}
	}
}