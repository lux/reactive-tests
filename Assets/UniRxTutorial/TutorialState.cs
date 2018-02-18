using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

namespace UniRxTutorial {

	public class TutorialState {
		public ReactiveProperty<int> step { get; private set; }
		public ReactiveProperty<bool> ready {get; private set; }
		public ReactiveProperty<bool> completed { get; private set; }

		private Step[] steps;

		public TutorialState () {
			step = new ReactiveProperty<int> (-1);
			ready = new ReactiveProperty<bool> (false);
			completed = step.Select (x => x > 0 && x == steps.Length).ToReactiveProperty ();
		}

		public void SetSteps (Step[] steps) {
			this.steps = steps;
			
			if (step.Value > -1) ready.Value = true;
		}

		public void SetInitialStep (int value) {
			// Validations
			if (value < 0 || value >= steps.Length) {
				value = 0;
			}

			step.Value = value;

			if (steps != null) ready.Value = true;
		}

		public void IncrementStep () {
			if (step.Value < steps.Length) step.Value++;
		}

		public int TotalSteps () {
			return steps.Length;
		}

		public Step CurrentStep (int num) {
			if (steps == null || num < 0 || num >= steps.Length) {
				return null;
			}

			return steps[num];
		}
	}
}