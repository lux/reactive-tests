using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorial {

	/// <summary>
	/// Updates and responds to UI interactions.
	/// </summary>
	public class TutorialView : MonoBehaviour {
		public Text stepTitle;
		public Text stepInstructions;
		public Button nextButton;

		private TutorialActions _actions;
		private TutorialState _state;

		private int currentStep;
		private Step[] steps;

		[Inject]
		private void Init (TutorialActions actions, TutorialState state) {
			_actions = actions;
			_state = state;
		}

		private void OnEnable () {
			_state.OnStepsReady += HandleStepsReady;
			_state.OnStepChanged += HandleStepChanged;
			_state.OnTutorialComplete += HandleCompleted;
			_state.OnError += HandleError;
		}

		private void OnDisable () {
			_state.OnStepsReady -= HandleStepsReady;
			_state.OnStepChanged -= HandleStepChanged;
			_state.OnTutorialComplete -= HandleCompleted;
			_state.OnError -= HandleError;
		}

		public void NextStep () {
			_actions.NextStep ();
		}

		public void HandleStepsReady (Step[] steps) {
			this.steps = steps;
		}

		public void HandleStepChanged (int step) {
			// Update UI with next step
			stepTitle.text = string.Format ("Step {0}: {1}", step + 1, steps[step].title);
			stepInstructions.text = steps[step].instructions;

			// Store current locally for transitions
			currentStep = step;
		}

		public void HandleCompleted () {
			// Update UI to show tutorial completed
			stepTitle.text = "Tutorial completed!";
			stepInstructions.text = "";

			nextButton.interactable = false;
		}

		public void HandleError (string err) {
			// Handle errors
			stepTitle.text = string.Format ("Error: {0}", err);
			stepInstructions.text = "";
		}
	}
}