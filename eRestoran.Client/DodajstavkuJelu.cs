﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using System.Net.Http;
using eRestoran.Data.Models;
using FastFoodDemo;
using eRestoran.PCL.VM;
using eRestoran.Client.Properties;

namespace eRestoran.Client
{
    public partial class DodajstavkuJelu : UserControl
    {
        private WebAPIHelper getProizvodi = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/GetProizvodi");

        public DodajstavkuJelu()
        {
            InitializeComponent();
            BindProizvodi();
        }

        public DodajstavkuJelu(ProizvodStavka stavka) : this()
        {
            KolicinaJelotextBox.Text = stavka.Kolicina.ToString();
            ProizvodJelo.SelectedValue = stavka.ProizvodId;
            ProizvodJelo.Enabled = false;
        }
        private void BindProizvodi()
        {
            HttpResponseMessage responseMessage = getProizvodi.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<Proizvod> lista = responseMessage.Content.ReadAsAsync<List<Proizvod>>().Result;
                lista.Insert(0, new Proizvod() { Naziv = "Odaberite proizvod", Id = 0 });

                ProizvodJelo.DataSource = lista;
                ProizvodJelo.DisplayMember = "Naziv";
                ProizvodJelo.ValueMember = "Id";
            }
        }

        public JelaStavke GetStavka()
        {
            return new JelaStavke()
            {
                Kolicina = int.Parse(KolicinaJelotextBox.Text),
                ProizvodId = (int)ProizvodJelo.SelectedValue
            };
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);

        }

        private void KolicinaJelotextBox_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(KolicinaJelotextBox.Text))
            {
                e.Cancel = true;
                KolicinaJelotextBox.Focus();
                errorProvider.SetError(KolicinaJelotextBox, Messages.Integer);
                return;
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(KolicinaJelotextBox.Text, "\\d+"))
                {
                    e.Cancel = true;
                    KolicinaJelotextBox.Focus();
                    errorProvider.SetError(KolicinaJelotextBox, Messages.Integer);
                    return;
                }
            }
            errorProvider.Clear();
        }

        private void ProizvodJelo_Validating(object sender, CancelEventArgs e)
        {
            if (ProizvodJelo.SelectedIndex == 0)
            {
                e.Cancel = true;
                KolicinaJelotextBox.Focus();
                errorProvider.SetError(ProizvodJelo, Messages.Univerzalno);
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
