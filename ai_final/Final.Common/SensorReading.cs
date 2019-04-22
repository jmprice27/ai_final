using System.Json;

namespace Final.Common
{
    public class SensorReading
    {
        float AngleRadians { get; }

        float Distance { get; }

		string Jsonify()
		{
			return "{ \"AngleRadians\": \"" + self.AngleRadians() + "\", \"Distance\": \"" + self.Distance() + "\" }";
			//return JsonObject.Parse(jsonstr);
		}
	}
}