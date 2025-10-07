namespace DataGrid1
{
    public class Track
    {
        public double TrackID;
        public string TrackNumber;
        public double TrackEven;
        public double DicTrackKindID;
        public string TrackName;

        public Track(
            double TrackID,
            string TrackNumber,
            double TrackEven,
            double DicTrackKindID,
            string TrackName)
        {
            this.TrackID = TrackID;
            this.TrackNumber = TrackNumber;
            this.TrackEven = TrackEven;
            this.DicTrackKindID = DicTrackKindID;
            this.TrackName = TrackName;
        }

    }
}