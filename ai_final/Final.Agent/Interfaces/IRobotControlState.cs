using System;
using System.Collections.Generic;
using System.Numerics;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    public interface IRobotControlState
    {
        double DemandedThroughput { get; }

        List<Node> RobotDestinations { get; }

        List<Vector2> RobotPositions { get; }

        List<SensorReading> Sensors { get; }

        DateTime Time { get; }

        Dictionary<Vector2, double> WorkerBeliefs { get; }

        double Evaluate( );

		public string Jsonify()
		{
			str_RobotDestinations = "[ ";
			this.RobotDestinations.ForEach(i => str_RobotDestinations += i.Jsonify() + ", ");
			str_RobotDestinations += "{} ]";
			str_RobotPositions = "[ ";
			this.RobotPositions.ForEach(i => str_RobotPositions += "{ \"X\": \"" i.X + "\", \"Y\": \"" i.Y + "\"}, ");
			str_RobotPositions += "{} ]";
			str_Sensors = "[ ";
			this.Sensors.ForEach(i => str_Sensors += i.Jsonify() + ", ");
			str_Sensors += "{} ]";
			//str_WorkerBeliefs = "[ ";
			//this.WorkerBeliefs.ForEach();
			//str_WorkerBeliefs += "{} ]";
			
			jsonstr = "{ \"DemandedThroughput\": \"" + self.DemandedThroughput() + "\"," +
			"\"RobotDestinations\": " + str_RobotDestinations + ", " + 
			"\"RobotPositions\": " + str_RobotPositions + ", " + 
			"\"Sensors\": " + str_Sensors + ", " + 
			"\"Time\": " + this.Time.ToString() + ", " + 
			//"\"WorkerBeliefs\": " + str_WorkerBeliefs + ", " + 
			"\"Evaluate\": " + this.Evaluate() + "}";
			
			return jsonstr;
			//return JsonObject.Parse(jsonstr);
		}
    }
}