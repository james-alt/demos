using PropertyChanged;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class ConferenceSelectionViewModel : BaseViewModel
	{
		public ConferenceSelectionViewModel ()
		{
		}

		public string ConferenceIdentifier { get; set; }

		public bool IsIdentifierValid
		{
			get {
				return ValidateConferenceIdentifier ();
			}
		}

		private bool ValidateConferenceIdentifier()
		{
			int value;
			if (int.TryParse (ConferenceIdentifier, out value)) {
				return true;
			}
			return false;
		}
	}
}

