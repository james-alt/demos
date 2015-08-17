using PropertyChanged;
using SQLSaturday.Data;
using Xamarin.Forms;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class ImageSpeaker : Speaker
	{
		public ImageSpeaker (Speaker speaker)
		{
			Id = speaker.Id;
			Name = speaker.Name;
			Description = speaker.Description;
			ImageUrl = speaker.ImageUrl;
		}

		public ImageSource ImageSource { get; set; }
	}
}

