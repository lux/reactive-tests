using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxCounter {

	public class CounterState {
		public ReactiveProperty<int> counter { get; private set; }
		
		public CounterState (int initialValue) {
			counter = new ReactiveProperty<int> (initialValue);
		}
		
		public void IncrementCounter () {
			counter.Value++;
		}
	}
}