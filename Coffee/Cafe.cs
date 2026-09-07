using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace Coffee
{
    public partial class Cafe : Form
    {
        // ==========================================
        // FOOD PRICES
        // ==========================================

        decimal burgerPrice = 85m;
        decimal chickenPrice = 75m;
        decimal spaghettiPrice = 95m;
        decimal friesPrice = 50m;

        // ==========================================
        // DRINK PRICES
        // ==========================================

        decimal softDrinkPrice = 35m;
        decimal icedTeaPrice = 40m;
        decimal coffeePrice = 45m;
        decimal waterPrice = 25m;


        // ==========================================
        // FORM
        // ==========================================

        public Cafe()
        {
            InitializeComponent();

            // Set default values
            SetDefaultValues();

            // Connect buttons
            btnCalculate.Click += btnCalculate_Click;
            btnClear.Click += btnClear_Click;
            btnAdd.Click += btnAdd_Click;
        }


        // ==========================================
        // DEFAULT VALUES
        // ==========================================

        private void SetDefaultValues()
        {
            // Food quantities
            numBurger.Value = 0;
            numChicken.Value = 0;
            numSpaghetti.Value = 0;
            numFries.Value = 0;

            // Drink quantities
            numSoftDrink.Value = 0;
            numIcedTea.Value = 0;
            numCoffee.Value = 0;
            numWater.Value = 0;

            // Checkboxes
            chkBurger.Checked = false;
            chkChicken.Checked = false;
            chkSpaghetti.Checked = false;
            chkFries.Checked = false;

            chkSoftDrink.Checked = false;
            chkIcedTea.Checked = false;
            chkCoffee.Checked = false;
            chkWater.Checked = false;

            chkSenior.Checked = false;

            // ComboBoxes
            cmbOrderType.SelectedIndex = -1;
            cmbFood.SelectedIndex = -1;
            cmbDrink.SelectedIndex = -1;
            

            // Billing
            txtSubtotal.Text = "Sub Total: ₱0.00";
            txtTotal.Text = "Total: ₱0.00";
            txtChange.Text = "Change: ₱0.00";

            txtPayment.Text = "";
        }


        // ==========================================
        // CALCULATE BUTTON
        // ==========================================

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // ======================================
            // 1. CHECK FOOD SELECTION
            // ======================================

            bool foodSelected =
                chkBurger.Checked ||
                chkChicken.Checked ||
                chkSpaghetti.Checked ||
                chkFries.Checked;

            if (!foodSelected)
            {
                MessageBox.Show(
                    "Please select at least one food item.",
                    "Food Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ======================================
            // 2. CHECK DRINK SELECTION
            // ======================================

            bool drinkSelected =
                chkSoftDrink.Checked ||
                chkIcedTea.Checked ||
                chkCoffee.Checked ||
                chkWater.Checked;

            if (!drinkSelected)
            {
                MessageBox.Show(
                    "Please select at least one drink.",
                    "Drink Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ======================================
            // 3. CHECK FOOD QUANTITIES
            // ======================================

            if (chkBurger.Checked && numBurger.Value <= 0)
            {
                MessageBox.Show(
                    "Burger quantity must be greater than zero.");

                return;
            }

            if (chkChicken.Checked && numChicken.Value <= 0)
            {
                MessageBox.Show(
                    "Chicken Sandwich quantity must be greater than zero.");

                return;
            }

            if (chkSpaghetti.Checked && numSpaghetti.Value <= 0)
            {
                MessageBox.Show(
                    "Spaghetti quantity must be greater than zero.");

                return;
            }

            if (chkFries.Checked && numFries.Value <= 0)
            {
                MessageBox.Show(
                    "French Fries quantity must be greater than zero.");

                return;
            }


            // ======================================
            // 4. CHECK DRINK QUANTITIES
            // ======================================

            if (chkSoftDrink.Checked && numSoftDrink.Value <= 0)
            {
                MessageBox.Show(
                    "Soft Drink quantity must be greater than zero.");

                return;
            }

            if (chkIcedTea.Checked && numIcedTea.Value <= 0)
            {
                MessageBox.Show(
                    "Iced Tea quantity must be greater than zero.");

                return;
            }

            if (chkCoffee.Checked && numCoffee.Value <= 0)
            {
                MessageBox.Show(
                    "Coffee quantity must be greater than zero.");

                return;
            }

            if (chkWater.Checked && numWater.Value <= 0)
            {
                MessageBox.Show(
                    "Bottled Water quantity must be greater than zero.");

                return;
            }


            // ======================================
            // 5. CALCULATE FOOD TOTAL
            // ======================================

            decimal foodTotal = 0;

            if (chkBurger.Checked)
            {
                foodTotal =
                    foodTotal +
                    (burgerPrice * numBurger.Value);
            }

            if (chkChicken.Checked)
            {
                foodTotal =
                    foodTotal +
                    (chickenPrice * numChicken.Value);
            }

            if (chkSpaghetti.Checked)
            {
                foodTotal =
                    foodTotal +
                    (spaghettiPrice * numSpaghetti.Value);
            }

            if (chkFries.Checked)
            {
                foodTotal =
                    foodTotal +
                    (friesPrice * numFries.Value);
            }


            // ======================================
            // 6. CALCULATE DRINK TOTAL
            // ======================================

            decimal drinkTotal = 0;

            if (chkSoftDrink.Checked)
            {
                drinkTotal =
                    drinkTotal +
                    (softDrinkPrice * numSoftDrink.Value);
            }

            if (chkIcedTea.Checked)
            {
                drinkTotal =
                    drinkTotal +
                    (icedTeaPrice * numIcedTea.Value);
            }

            if (chkCoffee.Checked)
            {
                drinkTotal =
                    drinkTotal +
                    (coffeePrice * numCoffee.Value);
            }

            if (chkWater.Checked)
            {
                drinkTotal =
                    drinkTotal +
                    (waterPrice * numWater.Value);
            }


            // ======================================
            // 7. SUBTOTAL
            // ======================================

            decimal subtotal = foodTotal + drinkTotal;

            txtSubtotal.Text =
                "Sub Total: " +
                subtotal.ToString("₱#,##0.00");


            // ======================================
            // 8. DISCOUNT
            // ======================================

            decimal discount = 0;

            // Automatic 10% discount
            // when subtotal is ₱500 or more

            if (subtotal >= 500)
            {
                discount =
                    discount +
                    (subtotal * 0.10m);
            }


            // ======================================
            // SENIOR CITIZEN DISCOUNT
            // ======================================

            if (chkSenior.Checked)
            {
                discount =
                    discount +
                    (subtotal * 0.20m);
            }


            // ======================================
            // DISPLAY DISCOUNT
            // ======================================

            if (chkSenior.Checked)
            {
                txtDiscount.Text = "20% Senior";
            }
            else if (subtotal >= 500)
            {
                txtDiscount.Text = "10% Discount";
            }
            else
            {
                txtDiscount.Text = "No Discount";
            }


            // ======================================
            // 9. ORDER TYPE
            // ======================================

            decimal orderCharge = 0;

            string orderType = cmbOrderType.Text;


            // DINE-IN
            if (orderType == "Dine-in")
            {
                orderCharge = 0;
            }


            // TAKE-OUT
            else if (orderType == "Take-out")
            {
                orderCharge = 20;
            }


            // DELIVERY
            else if (orderType == "Delivery")
            {
                if (subtotal >= 1000)
                {
                    orderCharge = 0;

                    MessageBox.Show(
                        "Your order reached ₱1,000.\n" +
                        "Delivery is FREE!",
                        "Free Delivery",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    orderCharge = 50;
                }
            }


            // ======================================
            // 10. FINAL TOTAL
            // ======================================

            decimal total =
                subtotal -
                discount +
                orderCharge;


            if (total < 0)
            {
                total = 0;
            }


            // Display total
            txtTotal.Text =
                "Total: " +
                total.ToString("₱#,##0.00");


            // ======================================
            // 11. CHECK PAYMENT
            // ======================================

            if (string.IsNullOrWhiteSpace(txtPayment.Text))
            {
                MessageBox.Show(
                    "Please enter the customer's payment.",
                    "Payment Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPayment.Focus();

                return;
            }


            // Check if payment contains letters
            decimal payment;

            if (!decimal.TryParse(
                txtPayment.Text,
                out payment))
            {
                MessageBox.Show(
                    "Payment must contain numbers only.",
                    "Invalid Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPayment.Focus();

                return;
            }


            // ======================================
            // 12. INSUFFICIENT PAYMENT
            // ======================================

            if (payment < total)
            {
                txtChange.Text =
                    "Change: ₱0.00";

                MessageBox.Show(
                    "INSUFFICIENT PAYMENT!\n\n" +
                    "Total: " +
                    total.ToString("₱#,##0.00") +
                    "\nPayment: " +
                    payment.ToString("₱#,##0.00"),
                    "Insufficient Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // ======================================
            // 13. CALCULATE CHANGE
            // ======================================

            decimal change =
                payment - total;


            txtChange.Text =
                "Change: " +
                change.ToString("₱#,##0.00");



            // ======================================
            // 14. DISPLAY RECEIPT
            // ======================================

            string receipt =
                                     "================================\r\n" +
                                               "Marts123 CAFÉ\r\n" +
                                     "================================\r\n\r\n";
             
            // Food items
            if (chkBurger.Checked)
            {
                decimal itemTotal = burgerPrice * numBurger.Value;

                receipt +=
                    "Burger " +
                    numBurger.Value +
                    " × ₱85 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkChicken.Checked)
            {
                decimal itemTotal = chickenPrice * numChicken.Value;

                receipt +=
                    "Chicken Sandwich " +
                    numChicken.Value +
                    " × ₱75 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkSpaghetti.Checked)
            {
                decimal itemTotal = spaghettiPrice * numSpaghetti.Value;

                receipt +=
                    "Spaghetti " +
                    numSpaghetti.Value +
                    " × ₱95 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkFries.Checked)
            {
                decimal itemTotal = friesPrice * numFries.Value;

                receipt +=
                    "French Fries " +
                    numFries.Value +
                    " × ₱50 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }


            // Drinks
            if (chkSoftDrink.Checked)
            {
                decimal itemTotal = softDrinkPrice * numSoftDrink.Value;

                receipt +=
                    "Soft Drink " +
                    numSoftDrink.Value +
                    " × ₱35 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkIcedTea.Checked)
            {
                decimal itemTotal = icedTeaPrice * numIcedTea.Value;

                receipt +=
                    "Iced Tea " +
                    numIcedTea.Value +
                    " × ₱40 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkCoffee.Checked)
            {
                decimal itemTotal = coffeePrice * numCoffee.Value;

                receipt +=
                    "Coffee " +
                    numCoffee.Value +
                    " × ₱45 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }

            if (chkWater.Checked)
            {
                decimal itemTotal = waterPrice * numWater.Value;

                receipt +=
                    "Bottled Water " +
                    numWater.Value +
                    " × ₱25 = " +
                    itemTotal.ToString("₱#,##0.00") +
                    "\r\n";
            }


            // Receipt summary
            receipt +=
                            "--------------------------------\r\n" +
                            "Order Type: " + orderType + "\r\n" +
                            "Subtotal: " + subtotal.ToString("₱#,##0.00") + "\r\n" +
                            "Discount: " + discount.ToString("₱#,##0.00") + "\r\n" +
                            "Order Charge: " + orderCharge.ToString("₱#,##0.00") + "\r\n" +
                            "--------------------------------\r\n" +
                            "TOTAL: " + total.ToString("₱#,##0.00") + "\r\n" +
                            "Payment: " + payment.ToString("₱#,##0.00") + "\r\n" +
                            "Change: " + change.ToString("₱#,##0.00") + "\r\n" +
                            "================================\r\n" +
                            "           THANK YOU!\r\n" +
                            "================================";


            // Display receipt in receipt box
            textReceipt.Text = receipt;

            // Show receipt
            // Display receipt inside the Receipt box
            textReceipt.Text = receipt;
        }


        // ==========================================
        // ADD BUTTON
        // ==========================================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool foodSelected =
                chkBurger.Checked ||
                chkChicken.Checked ||
                chkSpaghetti.Checked ||
                chkFries.Checked;

            bool drinkSelected =
                chkSoftDrink.Checked ||
                chkIcedTea.Checked ||
                chkCoffee.Checked ||
                chkWater.Checked;

            if (!foodSelected && !drinkSelected)
            {
                MessageBox.Show(
                    "Please select an item first.",
                    "No Item Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Selected items have been added to the order.",
                "Order Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // ==========================================
        // CLEAR BUTTON
        // ==========================================

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to clear the order?",
                    "Clear Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetDefaultValues();
            }
        }


        // ==========================================
        // EXISTING DESIGNER EVENTS
        // ==========================================
        // Your Designer already has these events.
        // Keep these methods so Visual Studio
        // does not show an event error.


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void label1_Click(object sender, EventArgs e)
        {
            // Title clicked
        }


        private void label2_Click(object sender, EventArgs e)
        {
            // Menu title clicked
        }


        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // Order type changed
        }
    }
}