using Xamarin.Forms;

namespace SQLSaturday
{
	public class LabelStyles
	{
		private readonly Style display4, display3, display2, display, headline,
		title, subhead, body2, body, caption, action;

		public LabelStyles (Color firstColor, Color secondColor)
		{
			display4 = CreateStyle (firstColor, 76, StyleKit.LightFont);
			display3 = CreateStyle (firstColor, 50, StyleKit.RegularFont);
			display2 = CreateStyle (firstColor, 42, StyleKit.RegularFont);
			display = CreateStyle (firstColor, 30, StyleKit.RegularFont);
			headline = CreateStyle (secondColor, 20, StyleKit.RegularFont, LineBreakMode.WordWrap);
			title = CreateStyle (firstColor, 16, StyleKit.MediumFont);
			subhead = CreateStyle (secondColor, 14, StyleKit.RegularFont, LineBreakMode.WordWrap);
			body2 = CreateStyle (firstColor, 12, StyleKit.MediumFont, LineBreakMode.WordWrap);
			body = CreateStyle (firstColor, 12, StyleKit.RegularFont, LineBreakMode.WordWrap);
			caption = CreateStyle (secondColor, 9, StyleKit.RegularFont, LineBreakMode.WordWrap);
			action = CreateStyle (firstColor, 16, StyleKit.LightFont, LineBreakMode.WordWrap);
		}

		#region StyleProperties

		public Style Display4 {
			get {
				return display4;
			}
		}

		public Style Display3 {
			get {
				return display3;
			}
		}

		public Style Display2 {
			get {
				return display2;
			}
		}

		public Style Display {
			get {
				return display;
			}
		}

		public Style Headline {
			get {
				return headline;
			}
		}

		public Style Title {
			get {
				return title;
			}
		}

		public Style Subhead {
			get {
				return subhead;
			}
		}

		public Style Body2 {
			get {
				return body2;
			}
		}

		public Style Body {
			get {
				return body;
			}
		}

		public Style Caption {
			get {
				return caption;
			}
		}

		public Style Action {
			get {
				return action;
			}
		}

		#endregion

		private Style CreateStyle (
			Color textColor, 
			double fontSize, 
			string fontFamily, 
			LineBreakMode breakmode = LineBreakMode.TailTruncation)
		{

			return new Style (typeof(Label)) {
				Setters = {
					new Setter { Property = Label.TextColorProperty, Value = textColor },
					new Setter { Property = Label.FontSizeProperty, Value = fontSize },
					new Setter { Property = Label.FontFamilyProperty, Value = fontFamily },
					new Setter { Property = Label.LineBreakModeProperty, Value = breakmode },
				}
			};
		}
	}
}