using System.Collections;
using UnityEngine;
using Zenject;

namespace Tutorial {

	public class TutorialActions : MonoBehaviour {
		private TutorialState _state;

		private string prefsKey = "lastStep";

		[Inject]
		private void Init (TutorialState state) {
			_state = state;

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
			_state.SetCurrent (initialStep);
		}

		public void NextStep () {
			// Business logic (sync to database, etc.) then update local state
			int nextStep = _state.CurrentStepNum () + 1;

			if (nextStep >= _state.TotalSteps ()) {
				PlayerPrefs.SetInt (prefsKey, 0); // Reset for next time
			} else {
				PlayerPrefs.SetInt (prefsKey, nextStep);
			}

			// Update state
			_state.IncrementStep ();
		}
	}
}