using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorial {

	public class TutorialView : MonoBehaviour {
		public Text stepTitle;
		public Text stepInstructions;
		public Button nextButton;

		private TutorialActions _actions;
		private TutorialState _state;

		[Inject]
		private void Init (TutorialActions actions, TutorialState state) {
			_actions = actions;
			_state = state;

			nextButton.interactable = false;
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
			nextButton.interactable = true;
		}

		public void HandleStepChanged (int step) {
			Step cur = _state.CurrentStep (step);
			if (cur == null) return;

			stepTitle.text = string.Format ("Step {0}: {1}", step + 1, cur.title);
			stepInstructions.text = cur.instructions;
		}

		public void HandleCompleted () {
			stepTitle.text = "Tutorial completed!";
			stepInstructions.text = "";

			nextButton.interactable = false;
		}

		public void HandleError (string err) {
			stepTitle.text = string.Format ("Error: {0}", err);
			stepInstructions.text = "";
		}
	}
}