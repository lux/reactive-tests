using System.Collections;
using UnityEngine;
using Zenject;
using UniRx;

namespace UniRxTutorial {

	public class TutorialStorage : MonoBehaviour {
		private TutorialState _state;

		private string prefsKey = "lastStep";

		[Inject]
		private void Init (TutorialState state) {
			_state = state;

			_state.step.Subscribe (HandleStepChanged).AddTo (this);
			_state.completed.Subscribe (HandleCompleted).AddTo (this);

			// Pretend to fetch initial state from the database
			StartCoroutine (FetchSteps ());
		}

		private IEnumerator FetchSteps () {
			yield return new WaitForSeconds (1f);

			Step[] steps = new Step[] {
				new Step ("First step", "..."),
				new Step ("Second step", "..."),
				new Step ("Third step", "...")
			};

			int initialStep = PlayerPrefs.GetInt (prefsKey, 0);

			_state.SetSteps (steps);
			_state.SetInitialStep (initialStep);
		}

		private void HandleStepChanged (int step) {
			if (! _state.ready.Value) return;
			PlayerPrefs.SetInt (prefsKey, step); // Update stored state
		}

		private void HandleCompleted (bool completed) {
			if (completed) PlayerPrefs.SetInt (prefsKey, 0); // Reset for next time
		}
	}
}