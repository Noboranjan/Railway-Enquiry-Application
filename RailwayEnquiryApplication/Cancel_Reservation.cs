﻿using RailwayEnquiryRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayEnquiryApplication
{
    public partial class Cancel_Reservation : Form
    {
        private string id;
        private string name;
        public Cancel_Reservation(string i, string n)
        {
            InitializeComponent();
            id = i;
            name = n;

            PassengerRepository Passrepo = new PassengerRepository();
            List<RTicket> tList = Passrepo.GetPassengerTicket(id);
            this.CancelReservationdGV.DataSource = tList;
        }

        private void BackbtnClicked(object sender, EventArgs e)
        {
            Passenger_Panel PP = new Passenger_Panel(id,name);
            PP.Show();
            this.Hide();
        }

        private void CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.CancelReservationdGV.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                this.Ticketidtbox.Text = row.Cells[0].Value.ToString();
                this.JDatetbox.Text = row.Cells[1].Value.ToString();
                this.Trainidtbox.Text = row.Cells[2].Value.ToString();
                //this.totbox.Text = row.Cells[3].Value.ToString();
                this.Passengeridtbox.Text = row.Cells[4].Value.ToString();
                this.SNotbox.Text = row.Cells[5].Value.ToString();
                this.Pricetbox.Text = row.Cells[6].Value.ToString();
            }
        }

        private void DeletebtnClicked(object sender, EventArgs e)
        {
            RTicket t = new RTicket();
            t.Ticketid = this.Ticketidtbox.Text;
            TicketRepository TicketRepo = new TicketRepository();
            if (TicketRepo.CancelReservation(t.Ticketid))
            {
                MessageBox.Show("Ticket Reservation Deleted", "Delete");
            }
            else
            {
                MessageBox.Show("Can Not Delete Data", "Delete Error");
            }
        }

        private void LoadbtnClicked(object sender, EventArgs e)
        {
            PassengerRepository Passrepo = new PassengerRepository();
            List<RTicket> tList = Passrepo.GetPassengerTicket(id);
            this.CancelReservationdGV.DataSource = tList;
        }
    }
}
