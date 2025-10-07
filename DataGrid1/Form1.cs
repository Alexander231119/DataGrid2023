using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;

namespace DataGrid1
{
    
    public partial class Form1 : Form
    {
        string ConnectSrting1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private string filename;
        public static string ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Demianka2017.mdb;";
        public double defaultspeed = 80; // км/ч
        SpeedrestrictionComparer sc = new SpeedrestrictionComparer(); 
        List<PointOnTrack> PointOnTracks = new List<PointOnTrack>(); // список точек на пути из базы
        List<PointOnTrack> StationPoints = new List<PointOnTrack>();// список точек на пути из базы, принадлежащих станциям
        List <PointOnTrack> KmPoints = new List<PointOnTrack>();// список точек километровых столбов, стрелок и тупиков
        List<PointOnTrack> SpeedRestrictionPoints = new List<PointOnTrack>();// точки ограничений скорости уже имеющихся  в базе
        List<SpeedRestriction> SpeedRestrictions = new List<SpeedRestriction>(); // список speedrestrictions
        List<Segment> Segments = new List<Segment>();
        List<Track> Tracks = new List<Track>();
        public string errormessage = "";

        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myConnection != null)
            myConnection.Close();
        }
        // кнопка проверить
        private void CheckButton_Click(object sender, EventArgs e)
        {
            if ((myConnection != null) && (SpeedRestrictions.Count() > 0))
            {
                foreach (SpeedRestriction s in SpeedRestrictions)
                {
                   errormessage += s.Start.CheckCoordinate(KmPoints, Segments);
                   errormessage += s.End.CheckCoordinate(KmPoints, Segments);

                    errormessage += s.CheckStartToEnd();
                }


                if(errormessage != "")
                MessageBox.Show(errormessage,"Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("ошибок не найдено", "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                errormessage = "";
            }
        }


        // Кнопка загрузить
        private void Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (myConnection != null)
                    myConnection.Close();


                PointOnTracks.Clear();
                SpeedRestrictions.Clear();
                Segments.Clear();
                StationPoints.Clear();
                KmPoints.Clear();
                Tracks.Clear();
                SpeedRestrictionPoints.Clear();
                speedRestrictionBindingSource.DataSource = null;

                //dataGridView1.Rows.Clear();
                //dataGridView1.Refresh();

                filename = openFileDialog1.FileName;
                ConnectString = ConnectSrting1 + filename + ";";
                
                LoadSpeedRestrictions();
                dataGridView1.Refresh(); // попробовать чтобы открывалась другая база после сохранения

                //var tokens = filename.Split('\');

                Text = "Постоянные ограничения сорости - " + filename;
            }
        }

        // Explicit predicate delegate.
        // предикат для поиска точки на пути принадлежащей к станции
        private static bool Findstation(PointOnTrack ptk)
        {
            if (ptk.DicPointOnTrackKindID == 8 ||
                ptk.DicPointOnTrackKindID == 27 ||
                ptk.DicPointOnTrackKindID == 28 ||
                ptk.DicPointOnTrackKindID == 29)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //предикат для поиска точек на пути км столбов и стрелок
        private static bool Findkm(PointOnTrack ptk)
        {
            if (ptk.DicPointOnTrackKindID == 0 ||
                ptk.DicPointOnTrackKindID == 27 ||
                ptk.DicPointOnTrackKindID == 28 ||
                ptk.DicPointOnTrackKindID == 29)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //предикат для поиска точек на пути постоянных ограничений скоростей
        private static bool Findspeed(PointOnTrack ptk)
        {
            if (ptk.DicPointOnTrackKindID == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // функция для кнопки Загрузить
        public void LoadSpeedRestrictions()
        {
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();

            string queryAllPoints =
                "SELECT P.DicPointOnTrackKindID, P.TrackObjectID, P.SegmentID, " +
                "P.PointOnTrackCoordinate, P.PointOnTrackKm, P.PointOnTrackPk, P.PointOnTrackM, " +
                "P.PointOnTrackUsageDirection, PS.PredefinedRouteSegmentFromStartToEnd, " +
                "iif(ST.StationName is null, iif(STDE.StationName is null, STCP.StationName, STDE.StationName), ST.StationName) AS Station " +
                "FROM (((((((PointOnTrack AS P " +
                "LEFT JOIN TrackObject AS [TO] ON P.TrackObjectID = TO.TrackObjectID) " +
                "LEFT JOIN Station AS[ST] ON TO.TrackObjectID = ST.TrackObjectID) " +
                "LEFT JOIN CrossingPiece AS CP ON TO.TrackObjectID = CP.TrackObjectID) " +
                "LEFT JOIN Station AS STCP ON CP.StationID = STCP.TrackObjectID) " +
                "LEFT JOIN DeadEnd AS DE ON TO.TrackObjectID = DE.TrackObjectID) " +
                "LEFT JOIN Station AS STDE ON DE.StationID = STDE.TrackObjectID) " +
                "LEFT JOIN PredefinedRouteSegment AS [PS] ON P.SegmentID = PS.SegmentID) " +
                "LEFT JOIN Segment AS S ON PS.SegmentID = S.SegmentID " +
                "WHERE (P.DicPointOnTrackKindID In (0,2,8,27,28,29) " +
                "AND P.SegmentID IN (SELECT SegmentID FROM PredefinedRouteSegment)) " +
                "ORDER BY PS.SegmentID, P.PointOntrackCoordinate* PS.PredefinedRouteSegmentFromStartToEnd + S.SegmentLength * ((PS.PredefinedRouteSegmentFromStartToEnd - 1) / (0 - 2))";


            OleDbCommand command = new OleDbCommand(queryAllPoints, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            // выбираем точки на пути из базы
            while (reader.Read())
            {
                PointOnTracks.Add(new PointOnTrack(
                    Convert.ToDouble(reader[0]),
                    Convert.ToDouble(reader[1]),
                    Convert.ToDouble(reader[2]),
                    Convert.ToDouble(reader[3]),
                    reader[4].ToString(),
                    Convert.ToDouble(reader[5]),
                    Convert.ToDouble(reader[6]),
                    Convert.ToDouble(reader[7]),
                    Convert.ToDouble(reader[8]),
                    reader[9].ToString()));
            }
            reader.Close();

            StationPoints = PointOnTracks.FindAll(Findstation);
            KmPoints = PointOnTracks.FindAll(Findkm);
            SpeedRestrictionPoints = PointOnTracks.FindAll(Findspeed);

             
            // загрузить сегменты из базы

            string querySegments =
                "SELECT S.SegmentID, S.SegmentName, S.SegmentLength, S.TrackID, PS.PredefinedRouteSegmentFromStartToEnd " +
                "FROM Segment AS S " +
                "LEFT JOIN PredefinedRouteSegment AS [PS] ON S.SegmentID = PS.SegmentID " +
                "WHERE S.SegmentID IN (SELECT SegmentID FROM PredefinedRouteSegment)";

            OleDbCommand command3 = new OleDbCommand(querySegments, myConnection);

            OleDbDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                Segments.Add(new Segment(
                    Convert.ToDouble(reader3[0]),
                    reader3[1].ToString(),
                    Convert.ToDouble(reader3[2]),
                    Convert.ToDouble(reader3[3]),
                    Convert.ToDouble(reader3[4])));
            }
            reader3.Close();

            // загрузить пути из базы

            string query4 =
                "SELECT TrackID, TrackNumber, TrackEven, DicTrackKindID, TrackName " +
                "FROM Track ";

            OleDbCommand command4 = new OleDbCommand(query4, myConnection);

            OleDbDataReader reader4 = command4.ExecuteReader();

            while (reader4.Read())
            {
                Tracks.Add(new Track(
                    Convert.ToDouble(reader4[0]),
                    reader4[1].ToString(),
                    Convert.ToDouble(reader4[2]),
                    Convert.ToDouble(reader4[3]),
                    reader4[4].ToString()));
            }
            reader4.Close();


            if (SpeedRestrictionPoints.Count != 0)
            {
                //MessageBox.Show("В базе уже имеются постоянные ограничения скоростей ", "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label1.Text = "В базе уже есть постоянные ограничения скоростей ";

                // заполняем список ограничений скоростей из базы

                string query6 =
                "SELECT TrackObjectID, PermanentRestrictionSpeed, PermRestrictionOnlyHeader, PermRestrictionForEmptyTrain " +
                "FROM PermanentRestriction ";
                OleDbCommand command6 = new OleDbCommand(query6, myConnection);

                OleDbDataReader reader6 = command6.ExecuteReader();

                while (reader6.Read())
                {
                    SpeedRestrictions.Add(new SpeedRestriction(
                        Convert.ToDouble(reader6[1]),
                        Convert.ToDouble(reader6[2]),
                        Convert.ToDouble(reader6[3]))
                    );
                    SpeedRestrictions[SpeedRestrictions.Count - 1].Start.TrackObjectID = Convert.ToDouble(reader6[0]);
                    SpeedRestrictions[SpeedRestrictions.Count - 1].End.TrackObjectID = Convert.ToDouble(reader6[0]);
                }
                reader6.Close();


                foreach (SpeedRestriction s in SpeedRestrictions)
                {
                    // находим точки соответствующие началу и концу ограничения
                    int index = SpeedRestrictionPoints.FindIndex(x => (x.TrackObjectID == s.Start.TrackObjectID) &&
                    (x.PointOnTrackUsageDirection*x.PredefinedRouteSegmentFromStartToEnd == 1));
                    
                    if (index >=0)
                    s.Start = new PointOnTrack(SpeedRestrictionPoints[index]);

                    int index2 = SpeedRestrictionPoints.FindIndex(x => (x.TrackObjectID == s.End.TrackObjectID) &&
                    (x.PointOnTrackUsageDirection * x.PredefinedRouteSegmentFromStartToEnd == -1));

                    if (index2 >= 0)
                        s.End = new PointOnTrack(SpeedRestrictionPoints[index2]);

                    s.RefreshStationMid(StationPoints);

                    errormessage += s.Start.CheckCoordinate(KmPoints, Segments);
                    errormessage += s.End.CheckCoordinate(KmPoints, Segments);
                }


                if (errormessage != "")
                    MessageBox.Show(errormessage, "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                errormessage = "";
                SpeedRestrictions.Sort(sc);               
            }
            else
            {

                // заполняем список ограничений скоростей по отобранным точкам на пути границ станций,стрелок и тупиков
                for (int i = 1; i < StationPoints.Count; i++)
                {

                    if (StationPoints[i - 1].SegmentID == StationPoints[i].SegmentID)
                    {

                        PointOnTrack start = new PointOnTrack(StationPoints[i - 1]);
                        //start.PointOnTrackUsageDirection = 1;
                        PointOnTrack end = new PointOnTrack(StationPoints[i]);
                        //start.PointOnTrackUsageDirection = -1;

                        double speed;
                        
                        if (start.TrackKind(Tracks, Segments) == 2)
                        {
                            speed = 40;
                        }
                        else
                        { speed = defaultspeed; }

                        SpeedRestrictions.Add(new SpeedRestriction(start, end, speed)); 

                        if (start.station == end.station)
                        {
                            SpeedRestrictions[SpeedRestrictions.Count - 1].Station = start.station.ToUpper();
                        }
                        else
                        {
                            SpeedRestrictions[SpeedRestrictions.Count - 1].Station = start.station.ToUpper() + " - " + end.station.ToUpper();
                        }
                    }
                }
                label1.Text = "Загруженны координаты границ станций, стрелок и тупиков";
            }

            // заполняем dataGrid View
            FillDataGrid();

        }

        // внести ограничения скоростей в базу данных
        private void TestButton3_Click(object sender, EventArgs e)
        {

            //удалить ограничения скорости из базы
            if (SpeedRestrictionPoints.Count > 0)
            {
                string query7 = "DELETE " +
                    "FROM PermanentRestriction ";
                    
                string query71 = "DELETE FROM TrackObject " +
                    "WHERE DicTrackObjectKindID = 8 ";

                string query72 = "DELETE FROM PointOnTrack " +
                    "WHERE DicPointOnTrackKindID = 2 ";
                OleDbCommand command7 = new OleDbCommand(query7, myConnection);
                OleDbCommand command71 = new OleDbCommand(query71, myConnection);
                OleDbCommand command72 = new OleDbCommand(query72, myConnection);

                command7.ExecuteNonQuery();
                command71.ExecuteNonQuery();
                command72.ExecuteNonQuery();
            }

            // внести величины скоростей из таблицы datagridview1 в список ограничений скоростей
            //valueschange();

            if ((myConnection != null) && (SpeedRestrictions.Count() > 0))
            {
                //найти наибольший TrackObjectId
                string query1 = "SELECT MAX(TrackObjectID) FROM TrackObject";
                OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                OleDbDataReader reader = command1.ExecuteReader();
                reader.Read();
                double TrackObjectID = Convert.ToDouble(reader[0]);
                reader.Close();

                //найти наибольший PointOntrackID
                string query3 = "SELECT MAX(PointOnTrackID) FROM PointOnTrack";
                OleDbCommand command3 = new OleDbCommand(query3, myConnection);
                OleDbDataReader reader3 = command3.ExecuteReader();
                reader3.Read();
                double PointOnTrackID = Convert.ToDouble(reader3[0]);
                reader3.Close();

                foreach (SpeedRestriction s in SpeedRestrictions)
                {

                    // внести ограничения скорости в таблицу TrackObject
                    TrackObjectID += 1;
                    string TrackObjectName = "огр. " + s.Value + " км/ч на " + s.Start.PointOnTrackKm + " км " + s.Start.PointOnTrackPk + " пк " + s.Start.PointOnTrackM.ToString("G", CultureInfo.InvariantCulture) + " м";

                    string query = "INSERT INTO TrackObject ( TrackObjectID, DicTrackObjectKindID, TrackObjectName) VALUES (" + TrackObjectID + ", 8, '" + TrackObjectName + "' )";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    // внести ограничения скоростей в таблицу PermanentRestriction
                    string query2 = "INSERT INTO PermanentRestriction (TrackObjectID, PermanentRestrictionSpeed, PermRestrictionOnlyHeader, PermRestrictionForEmptyTrain) VALUES ( " + TrackObjectID + ", " + s.Value + ", " + s.PermRestrictionOnlyHeader + ", " + s.PermRestrictionForEmptyTrain + " )";
                    OleDbCommand command2 = new OleDbCommand(query2, myConnection);
                    command2.ExecuteNonQuery();

                    // внести ограничения скоростей в таблицу PointOntrack
                    double PointOnTrackUsageDirection;

                    if (s.Start.PredefinedRouteSegmentFromStartToEnd == 1) // если на этом отрезки возрастает километраж
                    {
                        PointOnTrackID += 1;
                        PointOnTrackUsageDirection = 1;
                        InsertPointOntrack(TrackObjectID, PointOnTrackID, s.Start, PointOnTrackUsageDirection);

                        PointOnTrackID += 1;
                        PointOnTrackUsageDirection = -1;
                        InsertPointOntrack(TrackObjectID, PointOnTrackID, s.End, PointOnTrackUsageDirection);
                    }
                    else
                    {
                        PointOnTrackID += 1;
                        PointOnTrackUsageDirection = 1;
                        InsertPointOntrack(TrackObjectID, PointOnTrackID, s.End, PointOnTrackUsageDirection);

                        PointOnTrackID += 1;
                        PointOnTrackUsageDirection = -1;
                        InsertPointOntrack(TrackObjectID, PointOnTrackID, s.Start, PointOnTrackUsageDirection);
                    }
                }
                MessageBox.Show("Введены ограничения скорости \n всего: " + SpeedRestrictions.Count.ToString(), "Автозаполнение скоростей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                // считываем данные из базы заново после сохранения
                PointOnTracks.Clear();
                SpeedRestrictions.Clear();
                Segments.Clear();
                StationPoints.Clear();
                KmPoints.Clear();
                Tracks.Clear();
                SpeedRestrictionPoints.Clear();
                //dataGridView1.Rows.Clear();

                LoadSpeedRestrictions();
                dataGridView1.Refresh();
                }            
        }
        

        private void DefSpeedtextBox1_TextChanged(object sender, EventArgs e)
        {
            defaultspeed = Convert.ToDouble(DefSpeedtextBox1.Text);
        }

        // найти индекс сегмента по SegmentID
        public int SegmentIndexFind(double SegmentID)
        {           
           int index =  Segments.FindIndex((Segment) => Segment.SegmentID == SegmentID);
            return index;
        }

        // ввести в базу точку на пути
        void InsertPointOntrack(double TrackObjectID, double PointOnTrackID, PointOnTrack p, double PointOnTrackUsageDirection)
        {
            string query4 = "INSERT INTO PointOnTrack ( PointOnTrackID, DicPointOnTrackKindID, TrackObjectID, SegmentID, PointOnTrackCoordinate, PointOnTrackKm, PointOnTrackPk, PointOnTrackM, PointOnTrackUsageDirection ) " +
            "VALUES (" + PointOnTrackID + ", 2, " + TrackObjectID + ", " + p.SegmentID + ", " + p.PointOnTrackCoordinate.ToString("G", CultureInfo.InvariantCulture) + ", " + p.PointOnTrackKm + ", " + p.PointOnTrackPk.ToString("G", CultureInfo.InvariantCulture) + ", " + p.PointOnTrackM.ToString("G", CultureInfo.InvariantCulture) + ", " + PointOnTrackUsageDirection.ToString("G", CultureInfo.InvariantCulture) + " )";
            OleDbCommand command4 = new OleDbCommand(query4, myConnection);
            command4.ExecuteNonQuery();
        }


        // заполняем dataGrid View из data1
        private void FillDataGrid()
        {
            foreach(var sr in SpeedRestrictions)
            {
                sr.TrackToShow(Tracks, Segments);
            }
            speedRestrictionBindingSource.DataSource = null;
            speedRestrictionBindingSource.DataSource = SpeedRestrictions;
            dataGridView1.Refresh();
        }

        // заполняем значения dataGrid View из SpeedRestrictions
        private void RefillDataGrid()
        {
            for (int i = 0; i < SpeedRestrictions.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = SpeedRestrictions[i].Station;
                dataGridView1.Rows[i].Cells[1].Value = SpeedRestrictions[i].Start.SegmentID;
                dataGridView1.Rows[i].Cells[2].Value = SpeedRestrictions[i].Start.PointOnTrackKm;
                dataGridView1.Rows[i].Cells[3].Value = SpeedRestrictions[i].Start.PointOnTrackPk;
                dataGridView1.Rows[i].Cells[4].Value = SpeedRestrictions[i].Start.PointOnTrackM;
                dataGridView1.Rows[i].Cells[5].Value = SpeedRestrictions[i].End.PointOnTrackKm;
                dataGridView1.Rows[i].Cells[6].Value = SpeedRestrictions[i].End.PointOnTrackPk;
                dataGridView1.Rows[i].Cells[7].Value = SpeedRestrictions[i].End.PointOnTrackM;
                dataGridView1.Rows[i].Cells[8].Value = SpeedRestrictions[i].Value;
                dataGridView1.Rows[i].Cells[9].Value = SpeedRestrictions[i].PermRestrictionOnlyHeader;
                dataGridView1.Rows[i].Cells[10].Value = SpeedRestrictions[i].PermRestrictionForEmptyTrain;


            }
        }

        // внести все значения из таблицы datagridview1 в список ограничений скоростей
        private void Refilldata1()
        {
            for (int i = 0; i < SpeedRestrictions.Count(); i++)
            {
                SpeedRestrictions[i].Station = dataGridView1.Rows[i].Cells[0].Value.ToString();
                SpeedRestrictions[i].Start.SegmentID = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                SpeedRestrictions[i].Start.PointOnTrackKm = dataGridView1.Rows[i].Cells[2].Value.ToString();
                SpeedRestrictions[i].Start.PointOnTrackPk = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                SpeedRestrictions[i].Start.PointOnTrackM = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                SpeedRestrictions[i].End.PointOnTrackKm = dataGridView1.Rows[i].Cells[5].Value.ToString();
                SpeedRestrictions[i].End.PointOnTrackPk = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                SpeedRestrictions[i].End.PointOnTrackM = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                SpeedRestrictions[i].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
            }
        }


        // occurs when a mouse clicks on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowCoordinatesLabel();
        }
        // показать координаты сегмента и номер пути
        private void ShowCoordinatesLabel()
        {
            if (SpeedRestrictions.Count > 0 && (SpeedRestrictions.Count() > Convert.ToInt32(dataGridView1.CurrentCell.RowIndex)))
            {
                int Rowindex = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
                int SegmentsIndex = SegmentIndexFind(SpeedRestrictions[Rowindex].Start.SegmentID);

                if (SegmentsIndex >= 0)
                {
                    label1.Text =
                        "Координаты: " + SpeedRestrictions[Rowindex].Start.PointOnTrackCoordinate.ToString() +
                                   " " + SpeedRestrictions[Rowindex].End.PointOnTrackCoordinate.ToString() +
                        "  Сегмент: " + Segments[SegmentsIndex].SegmentID.ToString() +
                        "  Путь: " + SpeedRestrictions[Rowindex].TrackNumber;
                }
                else
                {
                    label1.Text = "Сегмент " + SpeedRestrictions[Rowindex].Start.SegmentID.ToString() + " вне маршрута";
                }
            }
        }

        // добавить Speedrestrictoin в data1
        // с координатами текущей строки таблицы и скоростью по умолчанию
        private void addspeedrestriction()
        {
            int rowindex = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);

            var start = new PointOnTrack(SpeedRestrictions[rowindex].Start);
            var end = new PointOnTrack(SpeedRestrictions[rowindex].End);

            var sr = new SpeedRestriction(start, end, defaultspeed, "");
            sr.TrackToShow(Tracks, Segments);
            //SpeedRestrictions.Add(sr);
            speedRestrictionBindingSource.Add(sr);
            SpeedRestrictions.Sort(sc);
            dataGridView1.Refresh();

            //data1.Add(new SpeedRestriction(data1[Rowindex].Start, data1[Rowindex].End, defaultspeed ));
            //dataGridView1.Rows.Add();
            //RefillDataGrid();

            //RefillDataGrid();
            //changeok = true;
        }
        // добавить Speedrestrictoin в data1 спомощью диалогового окна
        private void addspeedrestriction2()
        {
            int rowindex = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            double currentsegmentId = SpeedRestrictions[rowindex].Start.SegmentID;
            string currentstation = SpeedRestrictions[rowindex].Station;

            PointOnTrack start = new PointOnTrack(SpeedRestrictions[rowindex].Start);
            PointOnTrack end = new PointOnTrack(SpeedRestrictions[rowindex].End);

            //AddSpeedForm3 newAddSpeedForm3 = new AddSpeedForm3(currentsegmentId, currentstation);
            var newAddSpeedForm3 = new AddSpeedForm3(new SpeedRestriction(start, end, defaultspeed, SpeedRestrictions[rowindex].Station));

            if (newAddSpeedForm3.ShowDialog() != DialogResult.OK) return;

            if (newAddSpeedForm3.spd != null)
            { 
               
                //changeok = false;
                newAddSpeedForm3.spd.Start.RefreshCoordinate(KmPoints, Segments);
                newAddSpeedForm3.spd.End.RefreshCoordinate(KmPoints, Segments);

                //поменять местами начало и конец, если они не в том направлении
                if (newAddSpeedForm3.spd.CheckStartToEnd() != "")
                {
                    newAddSpeedForm3.spd.StartToEnd();
                }

                newAddSpeedForm3.spd.TrackToShow(Tracks, Segments);
                speedRestrictionBindingSource.Add(newAddSpeedForm3.spd);
                //SpeedRestrictions.Add(newAddSpeedForm3.spd);
                //dataGridView1.Rows.Add();
                //RefillDataGrid();

                SpeedRestrictions.Sort(sc);
                dataGridView1.Refresh();
                //RefillDataGrid();
                //changeok = true;
            }
        }

        // Конпка добавить
        private void Addbutton1_Click(object sender, EventArgs e)
        {

            if ((myConnection != null) && (SpeedRestrictions.Count() > 0))
                addspeedrestriction();
        }


        // Occures when changed value of a cell
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 )
            { 
            int i = dataGridView1.CurrentCell.RowIndex;
            SpeedRestrictions[i].Start.RefreshCoordinate(KmPoints, Segments);
            SpeedRestrictions[i].End.RefreshCoordinate(KmPoints, Segments);
            }

            ShowCoordinatesLabel();

        }
        //Удалить
        private void Deletebutton1_Click(object sender, EventArgs e)
        {
            if ((myConnection != null) && (SpeedRestrictions.Count() > 0))
            {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            //SpeedRestrictions.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            SpeedRestrictions.Sort(sc);
            dataGridView1.Refresh();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) // не работает c Alt, Shift и другими нужными клавишами ((
            {
                if ((myConnection != null) && (SpeedRestrictions.Count() > 0))
                    addspeedrestriction2();

            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ShowCoordinatesLabel();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var row = dataGridView1.Rows[e.RowIndex];
            var sr = (SpeedRestriction)row.DataBoundItem;
            //row.DefaultCellStyle.BackColor = string.IsNullOrEmpty(sr.Station) ? Color.Yellow : Color.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }    
}
