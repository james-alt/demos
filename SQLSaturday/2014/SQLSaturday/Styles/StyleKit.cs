using Xamarin.Forms;

namespace SQLSaturday
{
	public static class StyleKit
	{
		public static string LightFont = Device.OnPlatform ("HelveticaNeue-Light", "sans-serif-light", "");
		public static string RegularFont = Device.OnPlatform ("HelveticaNeue", "sans-serif", "");
		public static string MediumFont = Device.OnPlatform ("HelveticaNeue-Medium", "sans-serif-medium", "");

		public static LabelStyles DarkLabelStyles = new LabelStyles (Color.White, Colors.SecondaryTextColor);
		public static LabelStyles LightLabelStyles = new LabelStyles (Colors.TextColor, Colors.SecondaryTextColor);
	}
	
}