using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ООАП_лаба1
{
    public partial class Flowers : Form
    {
        public Flowers()
        {
            /*edFlowName.Text = "Роза";
            edFlowSort.Text = "Дикая";*/
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point LastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - LastPoint.X;
                    this.Top += e.Y - LastPoint.Y;

                }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void edFlowName_Enter(object sender, EventArgs e)
        {
            if (edFlowName.Text == "Розы")
            {
                edFlowName.ForeColor = Color.Black;
                edFlowName.Text = "";
            }
        }

        private void edFlowSort_Enter(object sender, EventArgs e)
        {
            if (edFlowSort.Text == "Дикая")
            {
                edFlowSort.ForeColor = Color.Black;
                edFlowSort.Text = "";
            }
        }

        private void edFlowSort_Leave(object sender, EventArgs e)
        {
            if (edFlowSort.Text == "") edFlowSort.Text = "Дикая";
            edFlowSort.ForeColor = Color.Gray;
        }

        private void edFlowName_Leave(object sender, EventArgs e)
        {
            if (edFlowName.Text == "") edFlowName.Text = "Роза";
            edFlowName.ForeColor = Color.Gray;
        }
        public interface Dacha
        {
            Dacha Clone();
          
        }

        public class Flower : Dacha
        {
            private String name;
            private String Sort; 
            private DateTime dataPlanting;
            private DateTime dataHarvesting;
            
            public Flower(String name, String Sort, DateTime dataPlanting, DateTime dataHarvesting)
            {
                this.name = name;
                this.Sort = Sort;   
                this.dataPlanting = dataPlanting;
                this.dataHarvesting = dataHarvesting;
            }
            public Flower Clone() 
            {
                return new Flower(this.name, this.Sort, this.dataPlanting, this.dataHarvesting);
            }
            public String GetName
            {
                get { return this.name; }
            }
            public void SetName(String name)
            {
                this.name = name;
            }
            public String GetSort
            {
                get { return this.Sort; }
            }
            public void SetSort(String Sort)
            {
                this.Sort = Sort;
            }


            public DateTime GetDataPlanting
            {
                get { return this.dataPlanting; }
            }

            public void SetDataPlantig(DateTime dataPlanting)
            {
                this.dataPlanting = dataPlanting;
            }

            public DateTime GetDataHarvesting
            {
                get { return this.dataHarvesting; }
            }
            public void SetDataHarvesting(DateTime DataHarvesting)
            {
                this.dataHarvesting = DataHarvesting;
            }


            Dacha Dacha.Clone()
            {
                throw new NotImplementedException();
            }
        }

        string flw_name;
        string flw_sort;
        int flw_colvo;
        DateTime flw_planting;
        DateTime flw_harvesting;
        
        private void button_save_flow_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `plants` ( `name`, `sort`, `DataPlanting`, `DataHarvesting`) VALUES (@flower, @sort, @planting, @harvesting);", db.GetConnection());
            db.openConnection();


           

            flw_name = edFlowName.Text;
            flw_sort = edFlowSort.Text;
            flw_planting = date_FLow_plant.Value;
            flw_harvesting = date_flow_Harv.Value;  
            flw_colvo = (int)edFlowColvo.Value;

            Flower flowerPrototype = new Flower(flw_name, flw_sort, flw_planting, flw_harvesting);

            command.Parameters.Add("@flower", MySqlDbType.VarChar);
            command.Parameters.Add("@sort", MySqlDbType.VarChar);
            command.Parameters.Add("@planting", MySqlDbType.DateTime);
            command.Parameters.Add("@harvesting", MySqlDbType.DateTime);

            for (int i = 0; i < flw_colvo; i++)
            {
                Flower clonnedflowerPrototype = flowerPrototype.Clone();

                // Установите значения параметров для каждой итерации
                command.Parameters["@flower"].Value = clonnedflowerPrototype.GetName;
                command.Parameters["@sort"].Value = clonnedflowerPrototype.GetSort;
                command.Parameters["@planting"].Value = clonnedflowerPrototype.GetDataPlanting;
                command.Parameters["@harvesting"].Value = clonnedflowerPrototype.GetDataHarvesting;
                if (command.ExecuteNonQuery() > 0)
                {
                    // Этот блок выполнится каждый раз, когда данные успешно добавятся в базу данных
                    label9.Text = "Цветы добавлены";
                }

            }

/*            //выполнение без использовния прототипа
            command.Parameters.Add("@flower", MySqlDbType.VarChar);
            command.Parameters.Add("@sort", MySqlDbType.VarChar);
            command.Parameters.Add("@planting", MySqlDbType.DateTime);
            command.Parameters.Add("@harvesting", MySqlDbType.DateTime);

            for (int i = 0; i < flw_colvo; i++)
            {
                Flower flowers = new Flower(flw_name, flw_sort, flw_planting, flw_harvesting);
                // Установите значения параметров для каждой итерации
                command.Parameters["@flower"].Value = flowers.GetName;
                command.Parameters["@sort"].Value = flowers.GetSort;
                command.Parameters["@planting"].Value = flowers.GetDataPlanting;
                command.Parameters["@harvesting"].Value = flowers.GetDataHarvesting;
                if (command.ExecuteNonQuery() > 0)
                {
                    // Этот блок выполнится каждый раз, когда данные успешно добавятся в базу данных
                    label9.Text = "Цветы добавлены";
                }

            }*/


            db.closeConnection();

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
