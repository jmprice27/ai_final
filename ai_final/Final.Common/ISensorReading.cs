using System.Json;

namespace Final.Common
{
    public interface ISensorReading
    {
        float AngleRadians { get; }

        float Distance { get; }

		String Jsonify()
		{
			return "{ \"AngleRadians\": \"" + self.AngleRadians() + "\", \"Distance\": \"" + self.Distance() + "\" }";
			//return JsonObject.Parse(jsonstr);
		}
	}
}