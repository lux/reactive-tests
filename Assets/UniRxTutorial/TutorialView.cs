using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace UniRxTutorial {

	public class TutorialView : MonoBehaviour {
		public Text stepTitle;
		public Text stepInstructions;
		public Button nextButton;

		private TutorialState _state;

		[Inject]
		private void Init (TutorialState state) {
			_state = state;

			_state.step.Subscribe (HandleStepChanged);
			_state.ready.Subscribe (HandleStepsReady);
			_state.completed.Subscribe (HandleCompleted);

			nextButton.OnClickAsObservable ().Subscribe (_ => NextStep ());
			nextButton.interactable = false;
		}

		public void NextStep () {
			_state.IncrementStep ();
		}

		public void HandleStepsReady (bool ready) {
			nextButton.interactable = ready;
		}

		public void HandleStepChanged (int step) {
			Step cur = _state.CurrentStep (step);
			if (cur == null) return;

			int total = _state.TotalSteps ();

			stepTitle.text = string.Format ("Step {0} of {1}: {2}", step + 1, total, cur.title);
			stepInstructions.text = cur.instructions;
		}

		public void HandleCompleted (bool completed) {
			if (! completed) return;

			stepTitle.text = "Tutorial completed!";
			stepInstructions.text = "";

			nextButton.interactable = false;
		}
	}
}