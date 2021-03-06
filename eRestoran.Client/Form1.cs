﻿using FirstUserControlUsage;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client;
using eRestoran.Client.Properties;
using eRestoran.Data.Models;
using System.Linq;
using eRestoran.PCL.VM;
using System.Threading.Tasks;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private LinkedList<Control> controlsHistory { get; set; }
        private CartIndexVM cart;
        public string activeControl { get; set; }
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public WebAPIHelper deleteProizvod = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/DeleteProizvod");
        public WebAPIHelper deleteJelo = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Jelo/DeleteJelo");
        public VerifikovanKorisnikVM VerifikovaniKorisnik; // za konstruktora


        public Form1(VerifikovanKorisnikVM korisnik)
        {
            VerifikovaniKorisnik = korisnik;
            controlsHistory = new LinkedList<Control>();
            InitializeComponent();
            string[] tipKorisnika = { "Admin", "Menadzer", "Klijent", "Konobar", "Kuhar", "Sanker" };
            korisnikLabel.Text = tipKorisnika[(int)korisnik.TipKorisnika];
            SetupLayoutForUser();
            cart = new CartIndexVM();
            cart.Jela = new List<CartRow>();
            cart.Pica = new List<CartRow>();
            cart.TotalPrice = 0.00;
            this.AutoValidate = AutoValidate.Disable;
            //cardsPanel1.SendToBack();
            //firstCustomControl2.SendToBack();
            btnHome_Click(btnHome, null);

            //dodajProizvod.Visible = false;
            //vScrollBar1.Visible = false;
            //activeControl = firstCustomControl1.Name;
        }

        private void SetupLayoutForUser()
        {
            if (VerifikovaniKorisnik.TipKorisnika == TipKorisnika.Admin || VerifikovaniKorisnik.TipKorisnika == TipKorisnika.Menadzer)
            {
                btnMenu.Visible = true;
                btnNalozi.Visible = true;
                btnPonuda.Visible = true;
                btnIzvjestaji.Visible = true;
                btnPromocije.Visible = true;
            }

        }

        public bool AddToCartPice(CartRow cartRow)
        {
            CartExists();
            if (cart.Pica.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                var staraKolicina = cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina;
                cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina = cartRow.Kolicina;
                cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice -= cartRow.Cijena * staraKolicina;
                label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }
            else
            {
                CartRow pice = new CartRow();
                pice.Id = cartRow.Id;
                pice.Kolicina = cartRow.Kolicina;
                pice.Naziv = cartRow.Naziv;
                pice.Cijena = cartRow.Cijena;
                pice.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.Pica.Add(pice);
                pice.Kategorija = cartRow.Kategorija;
                pice.StanjeKolicina = cartRow.StanjeKolicina;
                pice.Imageurl = cartRow.Imageurl;
                cart.TotalPrice += pice.TotalRowPrice;
                label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }

            SetBtnOdaberiStoVisibility();
            return true;
            //fali dio sa stanjem,da li ima stavke na stanju , treba uraditi poziv prema API
        }
        public bool AddToCartJelo(CartRow cartRow)
        {
            if (cart.Jela.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                var staraKolicina = cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina;
                cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina = cartRow.Kolicina;
                cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice -= cartRow.Cijena * staraKolicina;
                label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }
            else
            {
                CartRow jelo = new CartRow();
                jelo.Id = cartRow.Id;
                jelo.Kolicina = cartRow.Kolicina;
                jelo.Naziv = cartRow.Naziv;
                jelo.Kategorija = cartRow.Kategorija;
                jelo.Imageurl = cartRow.Imageurl;
                jelo.Cijena = cartRow.Cijena;
                jelo.StanjeKolicina = 0;
                jelo.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.Jela.Add(jelo);
                cart.TotalPrice += jelo.TotalRowPrice;
                label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }

            SetBtnOdaberiStoVisibility();
            return true;
        }

        public CartIndexVM GetCartForCheckout()
        {
            var checkoutCart = cart;
            ClearCart();
            return checkoutCart;
        }

        public int CartRowExists(int? id)
        {
            if (cart.Pica.SingleOrDefault(x => x.Id == id) != null)
            {
                return cart.Pica.SingleOrDefault(x => x.Id == id).Kolicina;
            }
            if (cart.Jela.SingleOrDefault(x => x.Id == id) != null)
            {
                return cart.Jela.SingleOrDefault(x => x.Id == id).Kolicina;
            }
            return 0;
        }

        public bool CartExists()
        {
            if (cart != null)
            {
                return true;
            }
            else
            {
                cart = new CartIndexVM();
                cart.Jela = new List<CartRow>();
                cart.Pica = new List<CartRow>();
                cart.TotalPrice = 0;
                return false;
            }

        }
        public List<CartRow> GetCartItems()
        {
            List<CartRow> SveStavkeKorpe = new List<CartRow>();
            SveStavkeKorpe.AddRange(cart.Jela.Where(x => x.Kolicina > 0));
            SveStavkeKorpe.AddRange(cart.Pica.Where(x => x.Kolicina > 0));
            return SveStavkeKorpe;

        }
        public double GetTotalPrice()
        {
            return cart.TotalPrice;
        }
        public void ClearCart()
        {
            cart = new CartIndexVM();
            cart.Jela = new List<CartRow>();
            cart.Pica = new List<CartRow>();
            cart.TotalPrice = 0;
            label4.Text = "0";
            SetBtnOdaberiStoVisibility();
        }

        private void SetBtnOdaberiStoVisibility()
        {
            if (cart.TotalPrice > 0)
            {
                btnOdaberiSto.Visible = true;
            }
            else
            {
                btnOdaberiSto.Visible = false;
            }
        }
        //cart
        public bool DeleteProizvod(string id)
        {

            HttpResponseMessage responseMessage = deleteProizvod.DeleteResponse(id);
            if (responseMessage.IsSuccessStatusCode)
            {

                var panel = NapraviPanelMenu();
                panel.DataBind();
                return true;
            }
            return false;

        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        public bool DeleteJelo(string id)
        {
            HttpResponseMessage responseMessage = deleteJelo.DeleteResponse(id);
            if (responseMessage.IsSuccessStatusCode)
            {

                NapraviPanelMenu();

                return true;
            }
            return false;

        }

        public void AddToControlHistory(Control control)
        {
            controlsHistory.AddLast(control);
        }
        public void GoBack()
        {
            if (controlsHistory.Count > 5)
            {
                controlsHistory.RemoveFirst();
            }
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(controlsHistory.Last.Value);

        }
        #region Events

        public CardsPanel NapraviPanelMenu()
        {
            var panel = new CardsPanel();
            Task.Run(() => { AddToControlHistory(panel); });
            cardsPanel1.Controls.Clear();

            cardsPanel1.Controls.Add(panel);
            var ponuda = GetPonuda();
            panel.PonudaViewModel = ponuda.ToList();
            var panelSize = cardsPanel1.Size;
            panelSize.Height -= 10;
            panel.Size = panelSize;

            panel.AutoScroll = true;

            return panel;
        }
        public CardsPanel NapraviPanelKorpa()
        {
            var ponuda = GetCartItems();
            var panel = new CardsPanel();
            panel.ViewModelKorpa = ponuda;
            var panelSize = cardsPanel1.Size;
            panelSize.Height -= 10;
            panel.Size = panelSize;

            panel.AutoScroll = true;
            cardsPanel1.Controls.Clear();
            if (ponuda.Count != 0)
                cardsPanel1.Controls.Add(panel);
            else
            {
                var label = new Label()
                {
                    Text = "KORPA JE PRAZNA !",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Left = 10,

                    Width = panel.Width - 10,
                    Height = panel.Height - 10
                };
                label.Font = new Font("Arial", 24, FontStyle.Bold);
                cardsPanel1.Controls.Add(label);
            }

            AddToControlHistory(panel);




            return panel;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li želite zatvoriti aplikaciju . Jeste li sigurni?", "Zatvori aplikaciju", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Methods

        private IEnumerable<PonudaVM.PonudaInfo> GetPonuda()
        {
            List<PonudaVM.PonudaInfo> cards = new List<PonudaVM.PonudaInfo>();
            HttpClient client = new HttpClient();
            List<PonudaVM.PonudaInfo> pica;
            client.BaseAddress = new Uri(Resources.apiUrlDevelopment);
            HttpResponseMessage response = client.GetAsync("api/PonudaAdministrator/GetPonuda").Result;
            if (response.IsSuccessStatusCode)
            {
                pica = response.Content.ReadAsAsync<List<PonudaVM.PonudaInfo>>().Result;
                foreach (var item in pica)
                {
                    item.Naziv = "NAZIV - " + item.Naziv;
                    item.KolicinaString = item.KolicinaString + " KOM";

                    yield return item;
                }
            }
        }

        public void SwitchActiveControls(Control newActiveControl)
        {
            var currentActiveControl = Controls.Find(activeControl, false)[0];
            if (currentActiveControl != null)
                currentActiveControl.Visible = false;
            newActiveControl.Visible = true;
            activeControl = newActiveControl.Name;
        }

        #endregion

        private void dodajProizvod_Click(object sender, EventArgs e)
        {
            // Treba li ovo ??
            //SidePanel.Height = button2.Height;
            //SidePanel.Top = button2.Top;
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(new UnosProizvoda());
            //firstCustomControl2.activeControl = Controls.Find(activeControl, false)[0];
            //SwitchActiveControls(firstCustomControl2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(new TipProizvodaCRUD());
            SetSideMenuPosition((Control)sender);
            //cardsPanel1.Controls.Add(new UnosJela());
        }
        public void DodajKontrolu(Control kontrola)
        {
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(kontrola);

        }
        public void izbrisiKontrolu(Control kontrola)
        {
            cardsPanel1.Controls.Remove(kontrola);
        }

        private void btnPonuda_Click(object sender, EventArgs e)
        {
            var panel = NapraviPanelMenu();
            panel.BindPonuda();
            SetSideMenuPosition((Control)sender);
        }

        private void SetSideMenuPosition(Control control)
        {
            SidePanel.Visible = true;
            SidePanel.Height = control.Height;
            SidePanel.Top = control.Top;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            cardsPanel1.Controls.Clear();
            var kont = new HomeControl();

            cardsPanel1.Controls.Add(kont);
            AddToControlHistory(kont);
            SetSideMenuPosition((Control)sender);

            //menu(menu) -> uredi
            //SwitchActiveControls(firstCustomControl1);
            //dodajProizvod.Visible = false;
        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            var panel = NapraviPanelKorpa();
            panel.BindKorpa();
            SidePanel.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li želite zatvoriti aplikaciju . Jeste li sigurni?", "Zatvori aplikaciju", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var panel = NapraviPanelMenu();
            panel.DataBind();
            SetSideMenuPosition((Control)sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DodajKontrolu(new KorisnickiNalozi());
            SetSideMenuPosition((Control)sender);
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            DodajKontrolu(new RezervacijaStola());
            SetSideMenuPosition((Control)sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var kont = new Izvjestaji();
            DodajKontrolu(kont);
            AddToControlHistory(kont);
            SetSideMenuPosition((Control)sender);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var kont = new eRestoran.Client.Promocija();
            DodajKontrolu(kont);
            AddToControlHistory(kont);
            SetSideMenuPosition((Control)sender);
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
