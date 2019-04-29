namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Final.Common;
    using Final.Warehouse;

    public class RobotControlState
    {
        public double DemandedThroughput { get; }

        public Node RobotDestination { get; }

        public Vector2 RobotPositions { get; }

        public List<SensorReading> Sensors { get; }

        public DateTime Time { get; }

        public Dictionary<Vector2, double> WorkerBeliefs { get; }

        public string Jsonify( )
        {
            var str_RobotDestinations = "[ ";
            str_RobotDestinations += this.RobotDestination.Jsonify( ) + ", ";
            str_RobotDestinations += "{} ]";
            var str_RobotPositions = "[ ";
            str_RobotPositions += "{ \"X\": \"" + this.RobotPositions.X + "\", \"Y\": \"" + this.RobotPositions.Y + "\"}, ";
            str_RobotPositions += "{} ]";
            var str_Sensors = "[ ";
            this.Sensors.ForEach( i => str_Sensors += i.Jsonify( ) + ", " );
            str_Sensors += "{} ]";

            //str_WorkerBeliefs = "[ ";
            //this.WorkerBeliefs.ForEach();
            //str_WorkerBeliefs += "{} ]";

            var jsonstr = "{ \"DemandedThroughput\": \"" + this.DemandedThroughput + "\"," +
            "\"RobotDestinations\": " + str_RobotDestinations + ", " +
            "\"RobotPositions\": " + str_RobotPositions + ", " +
            "\"Sensors\": " + str_Sensors + ", " +
            "\"Time\": " + this.Time.ToString( ) + ", " +

            //"\"WorkerBeliefs\": " + str_WorkerBeliefs + ", " +
            "\"Evaluate\": " + this.Evaluate( ) + "}";

            return jsonstr;

            //return JsonObject.Parse(jsonstr);
        }

        public double Evaluate( )
        {
            throw new NotImplementedException( );
        }
    }
}