using NUnit.Framework;

namespace SQLSaturday.Tests
{
	[TestFixture]
	public class ConferenceSelectionViewModelTests
	{
		[Test]
		public void IsIdentifierValidReturnsFalseOnEmptyString()
		{
			var viewModel = CreateConferenceSelectionViewModel ();
			viewModel.ConferenceIdentifier = string.Empty;
			Assert.IsFalse (viewModel.IsIdentifierValid);
		}

		[Test]
		public void IsIdentifierValidReturnsFalseOnNull()
		{
			var viewModel = CreateConferenceSelectionViewModel ();
			viewModel.ConferenceIdentifier = null;
			Assert.IsFalse (viewModel.IsIdentifierValid);
		}

		[Test]
		public void IsIdentifierValidReturnsFalseOnNonNumericString()
		{
			var viewModel = CreateConferenceSelectionViewModel ();
			viewModel.ConferenceIdentifier = "something";
			Assert.IsFalse (viewModel.IsIdentifierValid);
		}

		[Test]
		public void IsIdentifierValidReturnsFalseNonIntegerNumber()
		{
			var viewModel = CreateConferenceSelectionViewModel ();
			viewModel.ConferenceIdentifier = "123.4";
			Assert.IsFalse (viewModel.IsIdentifierValid);
		}

		[Test]
		public void IsIdentifierValidReturnsTrueOnInteger()
		{
			var viewModel = CreateConferenceSelectionViewModel ();
			viewModel.ConferenceIdentifier = "1234";
			Assert.IsTrue (viewModel.IsIdentifierValid);
		}

		#region Helpers

		private ConferenceSelectionViewModel CreateConferenceSelectionViewModel()
		{
			return new ConferenceSelectionViewModel ();
		}

		#endregion
	}
}

