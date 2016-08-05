using Android.Speech.Tts;
using Android.OS;
using Xamarin.Forms;
using sqlsaturdaydemo.Droid;

[assembly: Dependency (typeof (TextToSpeechDroid))]
namespace sqlsaturdaydemo.Droid
{
	public class TextToSpeechDroid : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speech;
		string lastText;

		public void Speak (string text)
		{
			if (speech == null) {
				lastText = text;
				speech = new TextToSpeech (Android.App.Application.Context, this);
			} else {
				if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
					speech.Speak (text, QueueMode.Flush, null, null);
				else {
#pragma warning disable 0618
					speech.Speak (text, QueueMode.Flush, null);
#pragma warning restore 0618
				}
			}
		}

		public void OnInit (OperationResult status)
		{
			if (status == OperationResult.Success) {
				if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
					speech.Speak (lastText, QueueMode.Flush, null, null);
				else {
#pragma warning disable 0618
					speech.Speak (lastText, QueueMode.Flush, null);
#pragma warning restore 0618
				}
				lastText = null;
			}
		}
	}
}
