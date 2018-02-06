using System.Collections;
using UnityEngine;
using Zenject;

namespace Tutorial {

	public class Actions : MonoBehaviour {
		private State _state;

		private string prefsKey = "lastStep";

		[Inject]
		private void Init (State state) {
			_state = state;

			// Fetch initial state from the database
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
			_state.SetCurrentStep (initialStep);
		}

		public void NextStep () {
			// Business logic, sync to web, etc. then update local state
			int nextStep = _state.GetCurrentStep () + 1;

			if (nextStep >= _state.StepsCount ()) {
				PlayerPrefs.SetInt (prefsKey, 0); // Reset for next time
			} else {
				PlayerPrefs.SetInt (prefsKey, nextStep);
			}

			// Update state
			_state.IncrementStep ();
		}
	}
}