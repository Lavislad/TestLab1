using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddDeliveryButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerNameTextBox.Text) ||
            string.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            DateTime deliveryDate = deliveryDatePicker.Value;
            Delivery newDelivery = new Delivery(customerNameTextBox.Text,
            addressTextBox.Text, deliveryDate);
            try
            {
                deliveryManager.AddDelivery(newDelivery);
                customerNameTextBox.Clear();
                addressTextBox.Clear();
                UpdateDeliveriesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RemoveDeliveryButton_Click(object sender, EventArgs e)
        {
            if (deliveriesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите доставку для удаления!");
                return;
            }
            string selectedItem = deliveriesListBox.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new[] { '-' }, StringSplitOptions.None);
            if (parts.Length >= 2)
            {
                string customerName = parts[0].Trim();
                string address = parts[1].Trim();
                var deliveryToRemove = deliveryManager.Deliveries.Find(d => d.CustomerName ==
                customerName && d.Address == address);
                if (deliveryToRemove != null)
                {
                    try
                    {
                        deliveryManager.RemoveDelivery(deliveryToRemove);
                        UpdateDeliveriesList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void UpdateStatusButton_Click(object sender, EventArgs e)
        {
            if (deliveriesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите доставку для обновления статуса!");
                return;
            }
            string selectedItem = deliveriesListBox.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new[] { '-' }, StringSplitOptions.None);
            if (parts.Length >= 2)
            {
                string customerName = parts[0].Trim();
                string address = parts[1].Trim();
                var deliveryToUpdate = deliveryManager.Deliveries.Find(d => d.CustomerName ==
                customerName && d.Address == address);
                if (deliveryToUpdate != null)
                {
                    DeliveryStatus newStatus = (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus),
                    statusComboBox.SelectedItem.ToString());
                    try
                    {
                        deliveryManager.UpdateDeliveryStatus(deliveryToUpdate, newStatus);
                        UpdateDeliveriesList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
