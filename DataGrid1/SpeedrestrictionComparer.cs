using System;
using System.Collections.Generic;

namespace DataGrid1
{
    //сравнение SpeedRestriction по segmentId и сoordinate и длине названия станции
    class SpeedrestrictionComparer : IComparer<SpeedRestriction>
    {
        public int Compare(SpeedRestriction x, SpeedRestriction y)
        {
            int a = Convert.ToInt32(x.Start.SegmentID);
            int b = Convert.ToInt32(y.Start.SegmentID);

            double c = x.Start.PointOnTrackCoordinate;
            double d = y.Start.PointOnTrackCoordinate;
            
            if ( a > b )
            {
                return 1;
            }
            else if ( a < b )
            {
                return -1;
            }
            else if ( a == b )
            {
                if (c > d)
                {
                    if (x.Start.PredefinedRouteSegmentFromStartToEnd == 1)
                        return 1;
                    else if (x.Start.PredefinedRouteSegmentFromStartToEnd == -1)
                        return -1;
                }
                else if (d > c)
                {
                    if (x.Start.PredefinedRouteSegmentFromStartToEnd == 1)
                        return -1;
                    else if (x.Start.PredefinedRouteSegmentFromStartToEnd == -1)
                        return 1;
                }
                else if (c == d)
                {

                    if (x.Station.Length > y.Station.Length)
                        return -1;
                    else if (x.Station.Length < y.Station.Length)
                        return 1;
                    else if (x.Station.Length == y.Station.Length)
                    {
                        if (Math.Abs(x.End.PointOnTrackCoordinate - x.Start.PointOnTrackCoordinate) > Math.Abs(y.End.PointOnTrackCoordinate - y.Start.PointOnTrackCoordinate))
                            return -1;
                        else if (Math.Abs(x.End.PointOnTrackCoordinate - x.Start.PointOnTrackCoordinate) < Math.Abs(y.End.PointOnTrackCoordinate - y.Start.PointOnTrackCoordinate))
                            return 1;
                    }
                }
                
            }

            return 0;
            //throw new NotImplementedException();
        }
    }
}