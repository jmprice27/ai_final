using System.Collections.Generic;
using System.Json;

namespace Final.Common
{
    internal interface ISensor
    {
        SensorOrientation Orientation { get; }

        IReadOnlyCollection<ISensorReading> SensorHits { get; }

		JsonObject Jsonify()
		{
			jsonstr = "{ \"Orientation\": \"" + this.Orientation() + "\", \"SensorHits\": " + this.SensorHits().Jsonify() + " }";
			return JsonObject.Parse(jsonstr);
		}
	}
}