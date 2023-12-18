using fiturReview_ady;
using fiturReview_ady.Properties;
using Npgsql;

namespace JT_APPS__Final_Voucher_
{
    public partial class rating3 : Form
    {
        public rating3()
        {
            InitializeComponent();
        }
        private int selectedRating;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
            RefreshRating();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=rembangan revisi;user id=postgres;password=123456"))
            {
                connection.Open();
                NpgsqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "insert into \"Penilaian\"(id_wisata,review,rating_tempat) values(@id_wisata,@review,@rating_tempat)";
                command.Parameters.Add(new NpgsqlParameter("@review", richTextBox1.Text));
                richTextBox1.Text = "";
                command.Parameters.AddWithValue("@id_wisata", "A04");
                command.Parameters.Add(new NpgsqlParameter("@rating_tempat", selectedRating));
                star1.Image = Resources.star__2___1_;
                star2.Image = Resources.star__2___1_;
                star3.Image = Resources.star__2___1_;
                star4.Image = Resources.star__2___1_;
                star5.Image = Resources.star__2___1_;
                selectedRating = 0;
                MessageBox.Show("Data Berhasil di Input");
                RefreshRating();
                command.ExecuteNonQuery();
                connection.Close();
                
            }
        }

        private void RefreshRating()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("host=localhost;port=5432;database=rembangan revisi;user id=postgres;password=123456"))
            {
                conn.Open();
                NpgsqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select AVG(rating_tempat) from \"Penilaian\" where id_wisata like'A04'";
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        float avgrating = reader.GetFloat(0);
                        label4.Text = avgrating.ToString("0.00");
                        if (avgrating >= 0.5 && avgrating < 1)
                        {
                            bintang1.Image = Resources.lopGroup_7;
                            bintang2.Image = Resources.lop0Group_9;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 1 && avgrating < 1.5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop0Group_9;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 1.5 && avgrating < 2)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lopGroup_7;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 2 && avgrating < 2.5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop0Group_9;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 2.5 && avgrating < 3)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lopGroup_7;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 3 && avgrating < 3.5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop0Group_9;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 3.5 && avgrating < 4)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lopGroup_7;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 4 && avgrating < 4.5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lopGroup_7;
                            bintang5.Image = Resources.lop0Group_9;
                        }
                        if (avgrating >= 4.5 && avgrating < 5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop2Group_8;
                            bintang5.Image = Resources.lopGroup_7;
                        }
                        if (avgrating == 5)
                        {
                            bintang1.Image = Resources.lop2Group_8;
                            bintang2.Image = Resources.lop2Group_8;
                            bintang3.Image = Resources.lop2Group_8;
                            bintang4.Image = Resources.lop2Group_8;
                            bintang5.Image = Resources.lop2Group_8;
                        }

                    }

                }
            }
        }
    }
}