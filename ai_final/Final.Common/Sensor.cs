namespace Final.Common
{
    using System;
    using System.Collections.Generic;
    using System.Json;

    internal class Sensor
    {
        SensorOrientation Orientation { get; }

        IReadOnlyCollection<SensorReading> SensorHits { get; }

		public string Jsonify()
		{
			var str_SensorHits = "[ ";

            throw new NotImplementedException( );
            //this.SensorHits.ToList().ForEach(i => str_SensorHits += i.Jsonify() + ", ");
			str_SensorHits = "{} ]";
			var jsonstr = "{ \"Orientation\": \"" + this.Orientation + "\", \"SensorHits\": " + str_SensorHits + " }";
			return JsonObject.Parse(jsonstr);
		}
	}
}