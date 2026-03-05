using System.Windows.Forms;

namespace TestLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Form

        private DeliveryManager deliveryManager;
        private TextBox customerNameTextBox;
        private TextBox addressTextBox;
        private DateTimePicker deliveryDatePicker;
        private ComboBox statusComboBox;
        private Button addDeliveryButton;
        private Button removeDeliveryButton;
        private Button updateStatusButton;
        private ListBox deliveriesListBox;

        private void InitializeComponent()
        {
            this.Text = "Управление доставкой";
            this.Width = 600;
            this.Height = 500;
            customerNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Width = 150,
                Text = "Имя"
            };
            addressTextBox = new TextBox
            {
                Location = new System.Drawing.Point(170, 10),
                Width = 200,
                Text = "Адрес"
            };
            deliveryDatePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(380, 10)
            };
            statusComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 100,
                Items = { "Новый", "В пути", "Доставлен" }
            };
            addDeliveryButton = new Button
            {
                Location = new System.Drawing.Point(10, 70),
                Text = "Добавить",
                Width = 100
            };
            addDeliveryButton.Click += AddDeliveryButton_Click;
            removeDeliveryButton = new Button
            {
                Location = new System.Drawing.Point(120, 70),
                Text = "Удалить",
                Width = 100
            };
            removeDeliveryButton.Click += RemoveDeliveryButton_Click;
            updateStatusButton = new Button
            {
                Location = new System.Drawing.Point(220, 70),
                Text = "Обновить статус",
                Width = 120
            };
            updateStatusButton.Click += UpdateStatusButton_Click;
            deliveriesListBox = new ListBox
            {
                Location = new System.Drawing.Point(10, 100),
                Width = 560,
                Height = 250
            };
            this.Controls.Add(customerNameTextBox);
            this.Controls.Add(addressTextBox);
            this.Controls.Add(deliveryDatePicker);
            this.Controls.Add(statusComboBox);
            this.Controls.Add(addDeliveryButton);
            this.Controls.Add(removeDeliveryButton);
            this.Controls.Add(updateStatusButton);
            this.Controls.Add(deliveriesListBox);
            deliveryManager = new DeliveryManager();
            UpdateDeliveriesList();
        }

        private void UpdateDeliveriesList()
        {
            deliveriesListBox.Items.Clear();
            foreach (var delivery in deliveryManager.Deliveries)
            {
                deliveriesListBox.Items.Add($"{delivery.CustomerName} - {delivery.Address} ({ delivery.Status})");
            }
        }
    }
}
        #endregion

