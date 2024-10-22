using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fly_bird
{
    public partial class Form1 : Form
    {
        //Boru hızıve ve yerçekimi için değişkenler
        int boruHızı=8;//pipes'speed
        int gravity = 8;//gravity aaffecting the brid
        int score = 0;//oyuncunun skoru
        public Form1()
        {
            InitializeComponent();
        }
        //form yüklendiğinde tetiklenen event
        private void Form1_Load(object sender, EventArgs e)
        {

        }
         //bir picturebox tıklandığında tetiklenen event
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
          //oyun zamanlayıcısının her bir tikinde gerçekleşen olaylar
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;//Flappy Bird'in yerçekimi etkisi ile hareketi
            BoruAlt.Left -= boruHızı;//alt borunun sola doğru hareketi
            BoruUst.Left -= boruHızı;//üst borunun sola doğru hareketi
            scoreText.Text = "score:" + score;//skorun güncellenmesi
            //alt boru ekrandan çıktığında yerine geri gönder
            if(BoruAlt.Left<-150)
            {
                BoruAlt.Left = 800;//alt boruyu yeniden başlat
                score++;  //skoru arttır
            }
            //üst boru ekrandan çıktığında yerine geri gönder
            if(BoruUst.Left<-180)
            {
                BoruUst.Left = 950;//üst boruyu yeniden başlat
                score++;//skoru arttır
            }
            //Flappy bird borulara veya zemine çarparsa oyunu bitir
            if(flappyBird.Bounds.IntersectsWith(BoruAlt.Bounds)||flappyBird.Bounds.IntersectsWith(BoruUst.Bounds)||flappyBird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endgame();//oyunu sonlandır

            }
            //skor 4'ü geçerse boru hızlandırıp zorluğu arttır
            if(score>4)
            {
                boruHızı = 15;//borular daha hızlı hareket eder
            }
            //eğer Flappy Bird çok yukarı çıkarsa oyunu bitir
            if(flappyBird.Top<-25)
            {
                endgame();//oyunu sonlandır
            }

        }
        //kılavye tuşuna basıldığında tetklenen event
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)//space tuşuna basılırsa
            {
                gravity = -8;//yerçekimini tersine çevir, kuşyukarı hareket eder
            }

        }
        //kılavye tuşu bırakıldığında tetiklenen event
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)//space tuşu bırakılırsa
            {
                gravity = 8;//yerçekimii normale döner,kuş aşağı hareket eder
            }

        }
        //oyun bittiğinde tetiklenen fonksiyon
        private void endgame()
        {
            gameTimer.Stop();//oyun zamanlayıcısını durdur
            scoreText.Text = "Game Over!!!";//oyun bitti mesajı

        }
    }
}
