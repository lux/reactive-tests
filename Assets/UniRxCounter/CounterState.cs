using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxCounter {

	public class CounterState : MonoBehaviour {
		public ReactiveProperty<int> counter { get; private set; }
		
		private void Awake () {
			counter = new ReactiveProperty<int> (0);
		}
		
		public void IncrementCounter () {
			counter.Value++;
		}
	}
}