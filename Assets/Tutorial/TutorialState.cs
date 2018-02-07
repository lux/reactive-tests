using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial {

	public class TutorialState {
		public delegate void StepChanged (int step);
		public StepChanged OnStepChanged;

		public delegate void Complete ();
		public Complete OnTutorialComplete;

		public delegate void StepsReady (Step[] steps);
		public StepsReady OnStepsReady;

		public delegate void ErrorOccurred (string err);
		public ErrorOccurred OnError;

		private Step[] steps;
		private int step = 0;

		public void SetSteps (Step[] steps) {
			this.steps = steps;

			if (OnStepsReady != null) OnStepsReady (steps);
		}

		public void SetCurrent (int cur) {
			// Validations
			if (cur < 0) {
				if (OnError != null) OnError ("Can't set step below zero");
				return;
			}

			if (cur >= steps.Length) {
				if (OnError != null) OnError ("Can't set step above number of steps in tutorial");
				return;
			}

			step = cur;

			if (OnStepChanged != null) OnStepChanged (step);
		}

		public void IncrementStep () {
			if (step + 1 == steps.Length) {
				if (OnTutorialComplete != null) OnTutorialComplete ();
				return;
			}

			step++;

			if (OnStepChanged != null) OnStepChanged (step);
		}

		public int CurrentStepNum () {
			return step;
		}

		public int TotalSteps () {
			return steps.Length;
		}

		public Step CurrentStep (int num) {
			if (num < 0 || num >= steps.Length) {
				if (OnError != null) OnError ("Step index is not valid.");
				return null;
			}

			return steps[num];
		}
	}
}