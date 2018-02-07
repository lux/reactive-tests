using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Counter {

	public class CounterView : MonoBehaviour {
		public Text label;

		private CounterActions _actions;
		private CounterState _state;

		[Inject]
		private void Init (CounterActions actions, CounterState state) {
			_actions = actions;
			_state = state;

			_state.OnCounterUpdated += HandleCounterUpdated;
		}

		public void IncrementCounter () {
			_actions.IncrementCounter ();
		}

		public void HandleCounterUpdated (int num) {
			label.text = num.ToString ();
		}
	}
}