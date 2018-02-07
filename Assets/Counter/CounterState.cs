namespace Counter {

	public class CounterState {
		public delegate void Updated (int counter);
		public Updated OnCounterUpdated;

		private int counter = 0;

		public void SetCounter (int num) {
			counter = num;

			if (OnCounterUpdated != null) OnCounterUpdated (counter);
		}

		public void IncrementCounter () {
			counter++;

			if (OnCounterUpdated != null) OnCounterUpdated (counter);
		}
	}
}