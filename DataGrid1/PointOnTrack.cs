using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataGrid1
{
    public class PointOnTrack
    {
        public string PointOnTrackKm;
        public double PointOnTrackPk;
        public double PointOnTrackM;

        public double DicPointOnTrackKindID;
        public double TrackObjectID;
        public double SegmentID;
        public double PointOnTrackCoordinate;
        public double PointOnTrackUsageDirection;
        public double PredefinedRouteSegmentFromStartToEnd;
        public string station = "";

        // конструктор
        public PointOnTrack(double DicPointOnTrackKindID, double TrackObjectID, double SegmentID, double PointOnTrackCoordinate, 
            string PointOnTrackKm, double PointOnTrackPk, double PointOnTrackM, 
            double PointOnTrackUsageDirection, double PredefinedRouteSegmentFromStartToEnd, string station)
        {
            this.DicPointOnTrackKindID = DicPointOnTrackKindID;
            this.TrackObjectID = TrackObjectID;
            this.SegmentID = SegmentID;
            this.PointOnTrackCoordinate = PointOnTrackCoordinate;
            this.PointOnTrackKm = PointOnTrackKm;
            this.PointOnTrackPk = PointOnTrackPk;
            this.PointOnTrackM = PointOnTrackM;
            this.PointOnTrackUsageDirection = PointOnTrackUsageDirection;
            this.PredefinedRouteSegmentFromStartToEnd = PredefinedRouteSegmentFromStartToEnd;
            this.station = station;
        }

        // конструктор
        public PointOnTrack(double DicPointOnTrackKindID, double SegmentID, double PointOnTrackCoordinate,
            string PointOnTrackKm, double PointOnTrackPk, double PointOnTrackM,
            double PointOnTrackUsageDirection, double PredefinedRouteSegmentFromStartToEnd, string station)
        {
            this.DicPointOnTrackKindID = DicPointOnTrackKindID;
            this.SegmentID = SegmentID;
            this.PointOnTrackCoordinate = PointOnTrackCoordinate;
            this.PointOnTrackKm = PointOnTrackKm;
            this.PointOnTrackPk = PointOnTrackPk;
            this.PointOnTrackM = PointOnTrackM;
            this.PointOnTrackUsageDirection = PointOnTrackUsageDirection;
            this.PredefinedRouteSegmentFromStartToEnd = PredefinedRouteSegmentFromStartToEnd;
            this.station = station;
        }

        // конструктор предложенный создать автоматически
        public PointOnTrack()
        {
        }

        public PointOnTrack(PointOnTrack point)
        {
            this.DicPointOnTrackKindID = point.DicPointOnTrackKindID;
            this.SegmentID = point.SegmentID;
            this.PointOnTrackCoordinate = point.PointOnTrackCoordinate;
            this.PointOnTrackKm = point.PointOnTrackKm;
            this.PointOnTrackPk = point.PointOnTrackPk;
            this.PointOnTrackM = point.PointOnTrackM;
            this.PointOnTrackUsageDirection = point.PointOnTrackUsageDirection;
            this.PredefinedRouteSegmentFromStartToEnd = point.PredefinedRouteSegmentFromStartToEnd;
            this.station = point.station;
        }

        // вычислить PointOntrackCoordinate по железнодорожным координатам
        public void RefreshCoordinate(List<PointOnTrack> points, List<Segment> segments)
        {
            string km = PointOnTrackKm;
            double segmentid = SegmentID;
            PointOnTrack p = new PointOnTrack();

            int index = points.FindIndex(x => (x.PointOnTrackKm == km) && (x.SegmentID == segmentid));
            int sindex = segments.FindIndex((Segment) => Segment.SegmentID == SegmentID);


            if (index >= 0)
            { 
                PointOnTrackCoordinate = points[index].PointOnTrackCoordinate
                                         - (points[index].PointOnTrackPk - 1) * 100 - points[index].PointOnTrackM
                                         + (PointOnTrackPk - 1) * 100 + PointOnTrackM;
            }
            else
            {
                if (sindex < 0) 
                    MessageBox.Show("Некорректный SegmentID ", "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("КМ " + PointOnTrackKm + " не соответствует SegmentID " + SegmentID.ToString(), 
                        "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            //округлить до сотых
            PointOnTrackCoordinate = Math.Round(PointOnTrackCoordinate, 2);
            // если координата близка к нулю
            if (PointOnTrackCoordinate < 0.001 && PointOnTrackCoordinate > -0.001)
                PointOnTrackCoordinate = 0;
        }

        // вычислить жд координату по PointOnTrackCoordinate
        public string RefreshKmPkM(List<PointOnTrack> points)
        {
            int index1 = points.FindIndex(x => (x.PointOnTrackCoordinate <= PointOnTrackCoordinate) && (x.SegmentID == SegmentID));
            int index2 = points.FindLastIndex(x => (x.PointOnTrackCoordinate <= PointOnTrackCoordinate) && (x.SegmentID == SegmentID));
            int index;

            /*
            if (index1 >= index2)
            {
                index = index1;
            }
            else
            {
                index = index2;
            }
            */
            index = Math.Max(index1, index2);

            string Km = points[index].PointOnTrackKm;
            double M = (PointOnTrackCoordinate - points[index].PointOnTrackCoordinate) % 100;
            double Pk = ((PointOnTrackCoordinate - points[index].PointOnTrackCoordinate) - PointOnTrackM) / 100 + 1;

            return PointOnTrackKm + " " + PointOnTrackPk.ToString() + " " + PointOnTrackM.ToString();
        }  


        // проверить координаты 
        public string CheckCoordinate(List<PointOnTrack> kmpoints, List<Segment> segments)
        {
            int kmindex = kmpoints.FindIndex(x => (x.PointOnTrackKm == PointOnTrackKm) && (x.SegmentID == SegmentID));
            int sindex = segments.FindIndex((Segment) => Segment.SegmentID == SegmentID);
            string message = "";
            int nextkmindex;
            if (PredefinedRouteSegmentFromStartToEnd == 1)
                nextkmindex = kmindex + 1;
            else
                nextkmindex = kmindex - 1;

            if (kmindex < 0)
            {
                message = "КМ " + PointOnTrackKm + " не соответствует SegmentID " + SegmentID.ToString() + " \n";
            }
            else if (
                nextkmindex < kmpoints.Count()
                && nextkmindex >= 0
                && (((PointOnTrackPk - kmpoints[kmindex].PointOnTrackPk) * 100 + PointOnTrackM - kmpoints[kmindex].PointOnTrackM) 
                    >= ( kmpoints[nextkmindex].PointOnTrackCoordinate - kmpoints[kmindex].PointOnTrackCoordinate))
                && kmpoints[kmindex].SegmentID == kmpoints[nextkmindex].SegmentID
                && kmpoints[kmindex].PointOnTrackKm != kmpoints[nextkmindex].PointOnTrackKm)
            {
                double value1 = (PointOnTrackPk - kmpoints[kmindex].PointOnTrackPk) * 100 + PointOnTrackM - kmpoints[kmindex].PointOnTrackM;
                double value2 = kmpoints[nextkmindex].PointOnTrackCoordinate - kmpoints[kmindex].PointOnTrackCoordinate;
                message = " ошибочная координата:  \n" +
                          PointOnTrackKm + "км " + PointOnTrackPk.ToString() + "пк " + PointOnTrackM.ToString() + "м  " + "SegmentID " + SegmentID.ToString() + " " +
                          value1.ToString() + " > " +
                          value2.ToString() +
                          " \n"; //если жд координата за пределами данного километра
            }

            if (sindex < 0)
            {
                message = PointOnTrackKm + "км " + PointOnTrackPk.ToString() + "пк " + PointOnTrackM.ToString() + "м  " +
                          "SegmentID " + SegmentID.ToString() + " вне маршрута \n";
            }
            
            else if (PointOnTrackCoordinate > segments[sindex].SegmentLength )
            {
                message = "Координата точки больше длины сегмента: \n" +
                          PointOnTrackKm + "км " + PointOnTrackPk.ToString() + "пк " + PointOnTrackM.ToString() + "м  " +
                          PointOnTrackCoordinate.ToString() + " > " + segments[sindex].SegmentLength.ToString() + " " + 
                          Math.Round(PointOnTrackCoordinate - segments[sindex].SegmentLength, 3 ).ToString() +  "\n";
            }
            else if (PointOnTrackCoordinate < 0)
            {
                message = "Отрицательная координата: \n" +
                          PointOnTrackKm + "км " + PointOnTrackPk.ToString() + "пк " + PointOnTrackM.ToString() + "м  " +
                          PointOnTrackCoordinate.ToString() + "\n";
            }

            return message;
        }


        // определить главный или боковой путь по индексам сегмента и пути

        public double TrackKind(List<Track> tracks, List<Segment> segments)
        {
            double trackkind = 1;
            int sindex = segments.FindIndex((Segment) => Segment.SegmentID == SegmentID);
            int tindex = tracks.FindIndex(x => (x.TrackID == segments[sindex].TrackID));

            return trackkind = tracks[tindex].DicTrackKindID;
        }

    }
}