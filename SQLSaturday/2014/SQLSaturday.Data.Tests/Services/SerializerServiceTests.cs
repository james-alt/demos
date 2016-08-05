using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SQLSaturday.Data.Tests
{
	[TestFixture]
	public class SerializerServiceTests
	{
		SerializerService _service;

		[SetUp]
		public void Init()
		{
			_service = new SerializerService ();
		}

		[TearDown]
		public void Cleanup()
		{
			_service = null;
		}

		#region Deserialize

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public async Task DeserializeNullStreamThrowsArgumentNullException()
		{
			await _service.Deserialize<object> (null);
		}

		#endregion
	}
}