using System.Collections.Generic;

namespace DataGrid1
{
    public class Segment
    {
        public double SegmentID;
        public string SegmentName;
        public double SegmentLength;
        public double TrackID;
        public double PredefinedRouteSegmentFromStartToEnd;

        //конструктор
        public Segment()
        {

        }
        public Segment(
            double SegmentID, 
            string SegmentName, 
            double SegmentLength, 
            double TrackID, 
            double PredefinedRouteSegmentFromStartToEnd)
        {
            this.SegmentID = SegmentID;
            this.SegmentName = SegmentName;
            this.SegmentLength = SegmentLength;
            this.TrackID = TrackID;
            this.PredefinedRouteSegmentFromStartToEnd = PredefinedRouteSegmentFromStartToEnd;
        }



    }
}