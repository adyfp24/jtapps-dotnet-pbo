using fiturReview_ady;
using fiturReview_ady.Properties;
using Npgsql;
using System.Windows.Forms;

namespace JT_APPS__Final_Voucher_
{
    public partial class rating : Form
    {
        private int selectedRating;
        public rating()
        {
            InitializeComponent();
        }

        private void star1_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star__1___1_;
            star2.Image = Resources.star__2___1_;
            star3.Image = Resources.star__2___1_;
            star4.Image = Resources.star__2___1_;
            star5.Image = Resources.star__2___1_;
            selectedRating = 1;

        }

        private void star2_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star__1___1_;
            star2.Image = Resources.star__1___1_;
            star3.Image = Resources.star__2___1_;
            star4.Image = Resources.star__2___1_;
            star5.Image = Resources.star__2___1_;
            selectedRating = 2;

        }

        private void star3_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star__1___1_;
            star2.Image = Resources.star__1___1_;
            star3.Image = Resources.star__1___1_;
            star4.Image = Resources.star__2___1_;
            star5.Image = Resources.star__2___1_;
            selectedRating = 3;

        }

        private void star4_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star__1___1_;
            star2.Image = Resources.star__1___1_;
            star3.Image = Resources.star__1___1_;
            star4.Image = Resources.star__1___1_;
            star5.Image = Resources.star__2___1_;
            selectedRating = 4;

        }

        private void star5_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star__1___1_;
            star2.Image = Resources.star__1___1_;
            star3.Image = Resources.star__1___1_;
            star4.Image = Resources.star__1___1_;
            star5.Image = Resources.star__1___1_;
            selectedRating = 5;

        }

        private void rating_Load(object sender, EventArgs e)
        {
            AverageRating();
            RefreshRatingTerakhir();
            RefreshUlasanTerakhir();
            JumlahReview();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "insert into \"penilaian\"(wisata_id_wisata,review,rating_tempat) values(@id_wisata,@review,@rating_tempat)";
                command.Parameters.Add(new NpgsqlParameter("@review", richTextBox1.Text));
                richTextBox1.Text = "";
                command.Parameters.AddWithValue("@id_wisata", "A01");
                command.Parameters.Add(new NpgsqlParameter("@rating_tempat", selectedRating));
                star1.Image = Resources.star__2___1_;
                star2.Image = Resources.star__2___1_;
                star3.Image = Resources.star__2___1_;
                star4.Image = Resources.star__2___1_;
                star5.Image = Resources.star__2___1_;
                selectedRating = 0;
                MessageBox.Show("Data Berhasil di Input");
                command.ExecuteNonQuery();
                connection.Close();
            }
            AverageRating();
            RefreshUlasanTerakhir();
            RefreshRatingTerakhir();
            JumlahReview();
        }

        private void AverageRating()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                conn.Open();
                NpgsqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select AVG(rating_tempat) from \"penilaian\" where wisata_id_wisata like'A01'";
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        float avgrating = reader.GetFloat(0);
                        label4.Text = avgrating.ToString("0.00");
                        if (avgrating >= 0.5 && avgrating < 1)
                        {
                            Bintang1.Image = Resources.lopGroup_7;
                            bintang2.Image = Resources.lop0Group_9;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 1 && avgrating < 1.5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop0Group_9;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 1.5 && avgrating < 2)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lopGroup_7;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 2 && avgrating < 2.5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 2.5 && avgrating < 3)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lopGroup_7;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 3 && avgrating < 3.5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 3.5 && avgrating < 4)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lopGroup_7;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 4 && avgrating < 4.5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lopGroup_7;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 4.5 && avgrating < 5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop2Group_8;
                            bintang5.Image = Resources.lopGroup_7;
                        }
                        if (avgrating == 5)
                        {
                            Bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop2Group_8;
                            bintang5.Image = Resources.lop2Group_8;
                        }

                    }

                }
            }
        }
        private void RefreshUlasanTerakhir()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT review FROM penilaian ORDER BY penilaian_id DESC LIMIT 1";

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string ulasan = reader.GetString(0);
                        this.lbUlasan.Text = ulasan;
                    }
                }

                connection.Close();
            }
        }
        private void RefreshRatingTerakhir()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT rating_tempat FROM penilaian ORDER BY penilaian_id DESC LIMIT 1";

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int star = reader.GetInt32(0);
                        if (star == 1)
                        {
                            showStar1.Image = Resources.star__1___1_;
                        }
                        if (star == 2)
                        {
                            showStar1.Image = Resources.star__1___1_;
                            showStar2.Image = Resources.star__1___1_;
                        }
                        if (star == 3)
                        {
                            showStar1.Image = Resources.star__1___1_;
                            showStar2.Image = Resources.star__1___1_;
                            showStar3.Image = Resources.star__1___1_;
                        }
                        if (star == 4)
                        {
                            showStar1.Image = Resources.star__1___1_;
                            showStar2.Image = Resources.star__1___1_;
                            showStar3.Image = Resources.star__1___1_;
                            showStar4.Image = Resources.star__1___1_;
                        }
                        if (star == 5)
                        {
                            showStar1.Image = Resources.star__1___1_;
                            showStar2.Image = Resources.star__1___1_;
                            showStar3.Image = Resources.star__1___1_;
                            showStar4.Image = Resources.star__1___1_;
                            showStar5.Image = Resources.star__1___1_;
                        }
                    }
                }
                connection.Close();
            }
        }
        private void JumlahReview()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT count(review) FROM penilaian";

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int jumlahReview = reader.GetInt32(0);
                        this.lbJumlahReview.Text = jumlahReview.ToString();
                    }
                }
                connection.Close();
            }
        }
        private void Bintang1_Click(object sender, EventArgs e)
        {

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=JT-Apps;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandText = "delete FROM penilaian where penilaian_id  = (SELECT penilaian_id FROM penilaian ORDER BY penilaian_id DESC LIMIT 1)";
                lbUlasan.Text = "";
                connection.Close();
            }
        }
    }
}