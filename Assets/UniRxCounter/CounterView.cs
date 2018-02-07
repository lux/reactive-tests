using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace UniRxCounter {

	public class CounterView : MonoBehaviour {
		public Text label;

		[Inject]
		private CounterState _state;

		private void Start () {
			_state.counter.SubscribeToText (label);
		}

		public void IncrementCounter () {
			_state.IncrementCounter ();
		}
	}
}