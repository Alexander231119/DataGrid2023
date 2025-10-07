using System.Collections.Generic;

namespace DataGrid1
{
    public class SpeedRestriction
    {
        public PointOnTrack Start { get; set; }

        public string StartPointOnTrackKm
        {
            get => Start.PointOnTrackKm;
            set => Start.PointOnTrackKm = value;
        }

        public double StarPointOnTrackPk
        {
            get => Start.PointOnTrackPk;
            set => Start.PointOnTrackPk = value;
        }

        public double StarPointOnTrackM
        {
            get => Start.PointOnTrackM;
            set => Start.PointOnTrackM = value;
        }
        //
        public double StartSegment
        {
            get => Start.SegmentID;
            set => Start.SegmentID = value;
        }

        public PointOnTrack End { get; set; }

        public string EndtPointOnTrackKm
        {
            get => End.PointOnTrackKm;
            set => End.PointOnTrackKm = value;
        }

        public double EndPointOnTrackPk
        {
            get => End.PointOnTrackPk;
            set => End.PointOnTrackPk = value;
        }

        public double EndPointOnTrackM
        {
            get => End.PointOnTrackM;
            set => End.PointOnTrackM = value;
        }

        public string TrackNumber { get; set; }


        public double Value { get; set; }
        public string Station { get; set; } = "";
        public double PermRestrictionOnlyHeader { get; set; }
        public double PermRestrictionForEmptyTrain { get; set; }

        //конструктор
        public SpeedRestriction(PointOnTrack Start, PointOnTrack End, double Value)
        {
            this.Start = Start;
            this.End = End;
            this.Value = Value;
        }

        //конструктор
        public SpeedRestriction(PointOnTrack Start, PointOnTrack End, double Value, string station)
        {
            this.Start = Start;
            this.End = End;
            this.Value = Value;
            this.Station = station;
        }

        public SpeedRestriction(double Value, double PermRestrictionOnlyHeader, double PermRestrictionForEmptyTrain)
        {
            this.Start = new PointOnTrack();
            this.End = new PointOnTrack();
            this.Value = Value;
            this.PermRestrictionOnlyHeader = PermRestrictionOnlyHeader;
            this.PermRestrictionForEmptyTrain = PermRestrictionForEmptyTrain;
        }

        public string TrackToShow(List<Track> tracks, List<Segment> segments)
        {
            int sindex = segments.FindIndex((Segment) => Segment.SegmentID == Start.SegmentID);
            int tindex = tracks.FindIndex(x => (x.TrackID == segments[sindex].TrackID));
            string tracktoshow = tracks[tindex].TrackNumber + " " + tracks[tindex].TrackName;

            if ( tracks[tindex].DicTrackKindID == 1)
            {
                //главный путь
                tracktoshow = tracks[tindex].TrackNumber + " гл.   " + tracks[tindex].TrackName;
            }
            else 
            {
                tracktoshow = tracks[tindex].TrackNumber + " бок   " + tracks[tindex].TrackName;
            }

            TrackNumber = tracktoshow;
            return tracktoshow;
        }

        


        // проверить направление ограничения от начала к концу
        public string CheckStartToEnd()
        {
            string message = "";

            if (((Start.PointOnTrackCoordinate > End.PointOnTrackCoordinate) && (Start.PredefinedRouteSegmentFromStartToEnd == 1)) ||
                ((Start.PointOnTrackCoordinate < End.PointOnTrackCoordinate) && (Start.PredefinedRouteSegmentFromStartToEnd == -1)))
            {
                message = "Начало и конец ограничения не совпадают с направлением движения: \n" +
                          Start.PointOnTrackKm + "км " + Start.PointOnTrackPk.ToString() + "пк " + Start.PointOnTrackM.ToString() + "м  " +
                          End.PointOnTrackKm + "км " +   End.PointOnTrackPk.ToString() + "пк " +   End.PointOnTrackM.ToString() + "м \n";

            }

            if (Start.PointOnTrackCoordinate == End.PointOnTrackCoordinate)
                message = "Ошибочная координата: \n" +
                          Start.PointOnTrackKm + "км " + Start.PointOnTrackPk.ToString() + "пк " + Start.PointOnTrackM.ToString() + "м  " +
                          End.PointOnTrackKm + "км " + End.PointOnTrackPk.ToString() + "пк " + End.PointOnTrackM.ToString() + "м \n";

            return message;
        }

        // поменять направление ограничения скорости
        public void StartToEnd()
        {
            string Km = Start.PointOnTrackKm;
            double Pk = Start.PointOnTrackPk;
            double M = Start.PointOnTrackM;
            double coordinate = Start.PointOnTrackCoordinate;

            Start.PointOnTrackKm = End.PointOnTrackKm;
            Start.PointOnTrackPk = End.PointOnTrackPk;
            Start.PointOnTrackM = End.PointOnTrackM;
            Start.PointOnTrackCoordinate = End.PointOnTrackCoordinate;

            End.PointOnTrackKm = Km;
            End.PointOnTrackPk = Pk;
            End.PointOnTrackM = M;
            End.PointOnTrackCoordinate = coordinate;

        }



        // определить по координатам на какой станции находится ограничение скорости
        public void RefreshStationMid(List<PointOnTrack> stationpoints)
        {
            double MidCoordinate = (Start.PointOnTrackCoordinate + End.PointOnTrackCoordinate) / 2;
            int index1;
            int index2;

            if (Start.PredefinedRouteSegmentFromStartToEnd == -1 )
            {
                index1 = stationpoints.FindIndex(y => ((y.PointOnTrackCoordinate <= MidCoordinate) && (y.SegmentID == Start.SegmentID)));
                index2 = stationpoints.FindLastIndex(x => ((x.PointOnTrackCoordinate >= MidCoordinate) && (x.SegmentID == Start.SegmentID)));
            }
            else
            {
                index1 = stationpoints.FindIndex(y => ((y.PointOnTrackCoordinate >= MidCoordinate) && (y.SegmentID == Start.SegmentID)));
                index2 = stationpoints.FindLastIndex(x => ((x.PointOnTrackCoordinate <= MidCoordinate) && (x.SegmentID == Start.SegmentID)));
            }

            if (index1 >= 0 && index2 >= 0)
            {
                if (stationpoints[index1].station == stationpoints[index2].station) // если точка на станции
                {
                    Station = stationpoints[index1].station;
                }
                else
                {
                    //if (Start.PredefinedRouteSegmentFromStartToEnd == 1)
                    //{
                    //    station = stationpoints[index1].station + " - " + stationpoints[index2].station;
                    //}
                    //else
                    //{
                    Station = stationpoints[index2].station + " - " + stationpoints[index1].station;
                    //}
                }
            }
            else
            {
                Station = index1.ToString() + " " + index2.ToString();
                
                /*
                MessageBox.Show("Присутствует ошибочное значение PointOnTrackCoordinate  \n " +
                    Start.PointOnTrackCoordinate.ToString() + " " + End.PointOnTrackCoordinate.ToString(),
                    "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    */
            }

            
            //station = station.ToUpper();
        }
    }
}