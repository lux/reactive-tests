using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial {

	/// <summary>
	/// State management and mutations.
	/// </summary>
	public class TutorialState {

		// Events to listen for updates
		public delegate void StepChanged (int step);

		public StepChanged OnStepChanged;

		public delegate void Complete ();

		public Complete OnTutorialComplete;

		public delegate void StepsReady (Step[] steps);

		public StepsReady OnStepsReady;

		public delegate void ErrorOccurred (string err);

		public ErrorOccurred OnError;

		// Internal data
		private Step[] steps;

		private int step = 0;

		/// <summary>
		/// Called by action during initializations.
		/// </summary>
		/// <param name="steps">List of steps.</param>
		public void SetSteps (Step[] steps) {
			this.steps = steps;

			if (OnStepsReady != null) OnStepsReady (steps);
		}

		/// <summary>
		/// Called by action during initializations.
		/// </summary>
		/// <param name="cur">Current step.</param>
		public void SetCurrentStep (int cur) {
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

		/// <summary>
		/// Increment the step state.
		/// </summary>
		public void IncrementStep () {
			if (step + 1 == steps.Length) {
				if (OnTutorialComplete != null) OnTutorialComplete ();
				return;
			}

			step++;

			if (OnStepChanged != null) OnStepChanged (step);
		}

		/// <summary>
		/// Get the current step.
		/// </summary>
		/// <returns>Current step.</returns>
		public int GetCurrentStep () {
			return step;
		}

		/// <summary>
		/// How many steps are there?
		/// </summary>
		/// <returns>Number of steps.</returns>
		public int StepsCount () {
			return steps.Length;
		}
	}
}