using AVFoundation;
using Xamarin.Forms;
using sqlsaturdaydemo.iOS;

[assembly: Dependency(typeof(TextToSpeechIOS))]
namespace sqlsaturdaydemo.iOS
{
	public class TextToSpeechIOS : ITextToSpeech
	{
		public void Speak (string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer ();
			speechSynthesizer.SpeakUtterance (new AVSpeechUtterance (text) {
				Rate = AVSpeechUtterance.DefaultSpeechRate,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = .5f,
				PitchMultiplier = 1.0f
			});
		}
	}
}
