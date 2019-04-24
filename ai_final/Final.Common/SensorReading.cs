namespace Final.Common
{
    public class SensorReading
    {
        float AngleRadians { get; }

        float Distance { get; }

		public string Jsonify()
		{
			return "{ \"AngleRadians\": \"" + this.AngleRadians + "\", \"Distance\": \"" + this.Distance + "\" }";
		}
	}
}