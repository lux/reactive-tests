using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Counter {

	public class CounterActions : MonoBehaviour {
		private CounterState _state;

		[Inject]
		private void Init (CounterState state) {
			_state = state;
		}

		private void OnEnable () {
			_state.SetCounter (0);
		}

		public void IncrementCounter () {
			_state.IncrementCounter ();
		}
	}
}