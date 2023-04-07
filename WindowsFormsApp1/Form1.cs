using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void instaAc()
        {
            //driver = webdriver.Chrome(ChromeDriverManager().install());
            //versiyondan kaynaklı hata veriyor.
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com/");
        }
        IWebDriver driver = null;

        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread islem = new Thread(instaAc);
            islem.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //mabelmatiz31fan takipçilere girdik
            driver.Url = ("https://www.instagram.com/mabelmatiz31fan/followers/");
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div/div/div[1]/div[1]/div[2]/section/main/div/header/section/ul/li[2]/a"));

            //tüm takipçilerin bulunduğu element (genel class pathini alıp içerisinde butonlu olan ifadeleri seçtik("takipten çıkar")
            //tüm takiplerin bulunduğu yerdeki butonlar da "takip et" butonu
            var takip = driver.FindElement(By.TagName("body")).FindElements(By.TagName("ul"));

            //yukarıda iki tane ul geliyo
            //ikinci ul bizim aradığımız element
            var butonlar = takip[1].FindElements(By.TagName("button"));

            //tüm takip et butonları içinde gez
            for(int i=0; i < butonlar.Count; i++)
            {
                //her 2 sn de bir bassın
                Thread.Sleep(2000);
                butonlar[i].Click();
            }

        }
    }
}
