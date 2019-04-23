using System.Collections.Generic;
using System.Json;

namespace Final.Common
{
    internal interface ISensor
    {
        SensorOrientation Orientation { get; }

        IReadOnlyCollection<ISensorReading> SensorHits { get; }

		public JsonObject Jsonify()
		{
			str_SensorHits = "[ ";
			this.SensorHits.ToList().ForEach(i => str_SensorHits += i.Jsonify() + ", ");
			str_SensorHits = "{} ]";
			jsonstr = "{ \"Orientation\": \"" + this.Orientation + "\", \"SensorHits\": " + str_SensorHits + " }";
			return JsonObject.Parse(jsonstr);
		}
	}
}