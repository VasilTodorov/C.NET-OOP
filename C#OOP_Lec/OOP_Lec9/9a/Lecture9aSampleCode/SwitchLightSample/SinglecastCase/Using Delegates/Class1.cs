using System;

namespace SwitchAndLight
{
	public enum SwitchPosition {Up, Down};

	delegate void SwitchFlipped(SwitchPosition switchState);

	class Light
	{
		private string name;

		public Light(string s) 
		{ 
			name = s; 
		}

		public void OnFlipCallback(SwitchPosition switchState)	
		{ 
			if (switchState == SwitchPosition.Up) 
			{
				Console.WriteLine("... {0} light is on",name);
			}
			else 
			{
				Console.WriteLine("... {0} light is off",name);
			}
		}
	}

	class Switch
	{
		private SwitchPosition switchState =
			SwitchPosition.Down;
		private SwitchFlipped switchFlippedHandler = null;

		public void ConnectToLight(SwitchFlipped lightHandler)	
		{
			switchFlippedHandler = lightHandler;
		}

		public SwitchPosition SwitchState 
		{
			get {return switchState;}
		}

		public void OnFlip() 
		{
			if (switchState == SwitchPosition.Down) 
			{
				switchState = SwitchPosition.Up;
			}
			else 
			{
				switchState = SwitchPosition.Down;
			}
			if (switchFlippedHandler != null) 
			{
				switchFlippedHandler(switchState);
			}
		}
	}

	class TheApp
	{
		static void OnFlip(Switch aSwitch) 
		{
			Console.WriteLine(
				"Before flipping, the switch is: {0}", 
				aSwitch.SwitchState);
			Console.WriteLine("Flipping switch ... ");
			aSwitch.OnFlip();
			Console.WriteLine(
				"After flipping, the switch is: {0}\n\n", 
				aSwitch.SwitchState);
		}

		static void Main(string[] args)	
		{
			Switch s = new Switch();
			Light light1 = new Light("bathroom");
			Light light2 = new Light("bedroom");

			// connect switch and bathroom light by passing a
			//   delegate to the bathroom light's
			//   OnFlipCallback method to s
			s.ConnectToLight(new 
				SwitchFlipped(light1.OnFlipCallback));
			OnFlip(s);
			OnFlip(s);

			// connect switch and bedroom light by passing a
			//   delegate to the bedroom's light's
			//   OnFlipCallback method to s
			s.ConnectToLight(new 
				SwitchFlipped(light2.OnFlipCallback));
			OnFlip(s);
			OnFlip(s);

		}
	}
}

