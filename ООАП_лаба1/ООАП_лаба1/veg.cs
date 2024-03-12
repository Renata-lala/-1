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
    public partial class veg : Form
    {
        public veg()
        {
            InitializeComponent();
        }



        public interface Dacha
        {
            Dacha Clone();

        }

        public class Veg : Dacha
        {
            private String name;
            private String Sort;
            private DateTime dataPlanting;
            private DateTime dataHarvesting;

            public Veg(String name, String Sort, DateTime dataPlanting, DateTime dataHarvesting)
            {
                this.name = name;
                this.Sort = Sort;
                this.dataPlanting = dataPlanting;
                this.dataHarvesting = dataHarvesting;
            }
            public Veg Clone()
            {
                return new Veg(this.name, this.Sort, this.dataPlanting, this.dataHarvesting);
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

        private void button_save_veg_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `plants` ( `name`, `sort`, `DataPlanting`, `DataHarvesting`) VALUES (@flower, @sort, @planting, @harvesting);", db.GetConnection());
            db.openConnection();




            flw_name = edVegName.Text;
            flw_sort = edVegSort.Text;
            flw_planting = date_veg_plant.Value;
            flw_harvesting = date_veg_Harv.Value;
            flw_colvo = (int)edVegColvo.Value;

            /*Veg flowerPrototype = new Veg(flw_name, flw_sort, flw_planting, flw_harvesting);*/

            /*command.Parameters.Add("@flower", MySqlDbType.VarChar);
            command.Parameters.Add("@sort", MySqlDbType.VarChar);
            command.Parameters.Add("@planting", MySqlDbType.DateTime);
            command.Parameters.Add("@harvesting", MySqlDbType.DateTime);

            for (int i = 0; i < flw_colvo; i++)
            {
                Veg clonnedflowerPrototype = flowerPrototype.Clone();

                // Установите значения параметров для каждой итерации
                command.Parameters["@flower"].Value = clonnedflowerPrototype.GetName;
                command.Parameters["@sort"].Value = clonnedflowerPrototype.GetSort;
                command.Parameters["@planting"].Value = clonnedflowerPrototype.GetDataPlanting;
                command.Parameters["@harvesting"].Value = clonnedflowerPrototype.GetDataHarvesting;
                if (command.ExecuteNonQuery() > 0)
                {
                    // Этот блок выполнится каждый раз, когда данные успешно добавятся в базу данных
                    label9.Text = "Овощи добавлены";
                }
*/
            //}

            //выполнение без использовния прототипа
            command.Parameters.Add("@flower", MySqlDbType.VarChar);
            command.Parameters.Add("@sort", MySqlDbType.VarChar);
            command.Parameters.Add("@planting", MySqlDbType.DateTime);
            command.Parameters.Add("@harvesting", MySqlDbType.DateTime);

            for (int i = 0; i < flw_colvo; i++)
            {
               Veg flowers = new Veg(flw_name, flw_sort, flw_planting, flw_harvesting);
                // Установите значения параметров для каждой итерации
                command.Parameters["@flower"].Value = flowers.GetName;
                command.Parameters["@sort"].Value = flowers.GetSort;
                command.Parameters["@planting"].Value = flowers.GetDataPlanting;
                command.Parameters["@harvesting"].Value = flowers.GetDataHarvesting;
                if (command.ExecuteNonQuery() > 0)
                {
                    // Этот блок выполнится каждый раз, когда данные успешно добавятся в базу данных
                    label9.Text = "Овощи добавлены";
                }

            }


            db.closeConnection();

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }
    }
}
