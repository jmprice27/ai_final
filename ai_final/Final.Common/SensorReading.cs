namespace Final.Common
{
    public class SensorReading
    {
        public float AngleRadians { get; }

        public float Distance { get; }

        public string Jsonify( )
        {
            return "{ \"AngleRadians\": \"" + this.AngleRadians + "\", \"Distance\": \"" + this.Distance + "\" }";
        }
    }
}