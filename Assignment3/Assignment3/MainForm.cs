using System;
using System.Windows.Forms;

/**
 * Main class for displaying a form containing options to calculate
 * one's BMI and a form for calculating one's fuel consumption.
 * Created by Jonas Eiselt on 2018-10-23.
 */
namespace Assignment3
{
    public partial class MainForm : Form
    {
        private FuelCalculator fuelCalculator = new FuelCalculator();
        private BmiCalculator bmiCalculator = new BmiCalculator();

        private string name = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraphicalUserInterface();
        }

        /* 
         * Clears textboxes and labels and sets a default value
		 * for the application's radio button form
         */
        private void InitializeGraphicalUserInterface()
        {
            clearTextBoxesInFuelForm();
            clearOutputLabelsInFuelResults();

            clearTextBoxesInBmiForm();
            clearOutputLabelsInBmiResults();

            setDefaultValues();
        }

        /* Clears the text boxes in the fuel form (input) */
        private void clearTextBoxesInFuelForm()
        {
            currentReadingTextBox.Text = string.Empty;
            previousReadingTextBox.Text = string.Empty;
            currentReadingTextBox.Text = string.Empty;
            pricePerLiterTextBox.Text = string.Empty;
        }

        /* 
         * Clears the output labels, ie the labels that are used for 
         * displaying the fuel results 
         */
        private void clearOutputLabelsInFuelResults()
        {
            kmPerLiterLabel.Text = string.Empty;
            literPerKmLabel.Text = string.Empty;
            literPerMetricMileLabel.Text = string.Empty;
            literPer10KmLabel.Text = string.Empty;
            costPerKmLabel.Text = string.Empty;
        }

        /* Clears text boxes in the BMI form */
        private void clearTextBoxesInBmiForm()
        {
            nameTextBox.Text = string.Empty;
            heightTextBox.Text = string.Empty;
            weightTextBox.Text = string.Empty;
        }

        /* Clears the output labels */
        private void clearOutputLabelsInBmiResults()
        {
            bmiLabel.Text = string.Empty;
            bmiWeightCategoryLabel.Text = string.Empty;
        }

        /* Sets default values for BMI form */
        private void setDefaultValues()
        {
            metricUnitRadioButton.Checked = true;
            usUnitRadioButton.Checked = false;

            bmiHeightLabel.Text = "Height (cm)";
            bmiWeightLabel.Text = "Weight (kg)";
        }

        /* 
         * Clears any previous data in the fuel results and reads the entered 
         * data in the fuel form 
         */
        private void fuelButton_Click(object sender, EventArgs e)
        {
            clearOutputLabelsInFuelResults();

            bool success = readFuelDetails();
            if (success)
            {
                // Make sure that the entered values make sense
                if (fuelCalculator.ValidateOdometerValues())
                {
                    if (fuelCalculator.ValidatePricePerLiterValue())
                        updateFuelResults();
                    else
                        showErrorMessage("The gas price cannot be negative!");
                }
                else
                {
                    showErrorMessage("The odometer values do not seem to make " +
                        "sense. Make sure that current odometer value is greater " +
                        "than the previous one and that the previous odometer " +
                        "value is not negative. ");
                }
            }
            else
            {
                showErrorMessage("The input must be numbers. If you are using decimal " +
                    "numbers, make sure that the appropriate decimal sign is used!");
            }
        }

        private bool readFuelDetails()
        {
            // Read current odometer reading
            double value = 0;
            if (double.TryParse(currentReadingTextBox.Text.Trim(), out value))
                fuelCalculator.SetCurrentReading(value);
            else
                return false;

            // Read previous odometer reading
            value = 0;
            if (double.TryParse(previousReadingTextBox.Text.Trim(), out value))
                fuelCalculator.SetPreviousReading(value);
            else
                return false;

            // Read current tanked amount of fuel
            value = 0;
            if (double.TryParse(fuelTankedTextBox.Text.Trim(), out value))
                fuelCalculator.SetFuelAmountTanked(value);
            else
                return false;

            // Read price per liter
            value = 0;
            if (double.TryParse(pricePerLiterTextBox.Text.Trim(), out value))
                fuelCalculator.SetPricePerLiter(value);
            else
                return false;

            return true;
        }

        /* 
         * Update fuel results by performing calculations based on entered data in 
         * the fuel form 
         */
        private void updateFuelResults()
        {
            kmPerLiterLabel.Text = fuelCalculator.CalculateFuelConsumption(
                FuelCalculator.Unit.KM_PER_LITER).ToString("0.00");
            literPerKmLabel.Text = fuelCalculator.CalculateFuelConsumption(
                FuelCalculator.Unit.LITERS_PER_KM).ToString("0.00");
            literPerMetricMileLabel.Text = fuelCalculator.CalculateFuelConsumption(
                FuelCalculator.Unit.LITERS_PER_METRIC_MILE).ToString("0.00");
            literPer10KmLabel.Text = fuelCalculator.CalculateFuelConsumption(
                FuelCalculator.Unit.LITERS_PER_10_KM).ToString("0.00");
            costPerKmLabel.Text = fuelCalculator.CalculateCostPerKm().ToString("0.00"); ;
        }

        /* Button for calculating BMI triggers this function */ 
        private void bmiButton_Click(object sender, EventArgs e)
        {
            clearOutputLabelsInBmiResults();

            // Set unit type depending on metricUnitRadioButton's checked state
            if (metricUnitRadioButton.Checked)
                bmiCalculator.SetUnit(BmiCalculator.Unit.METRIC);
            else
                bmiCalculator.SetUnit(BmiCalculator.Unit.US);

            // Read values from the text boxes concerning the bmi
            readName();
            bool success = readHeightAndWeigth();

            // Calculate and display bmi if values were parsed successfully
            if (success)
            {
                bmiCalculator.Calculate();
                updateBmiResults();
            }
            else
            {
                showErrorMessage("Height and weight must be numbers. If you are using decimal " +
                                    "numbers, make sure that the appropriate decimal sign is used!");
            }
        }

        /* Read name from text box */
        private void readName()
        {
            nameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(nameTextBox.Text))
                name = " unknown user";
            else
                name = nameTextBox.Text;
        }

        /* Read height and weight from text boxes */
        private bool readHeightAndWeigth()
        {
            // Read height
            double value = 0;
            if (double.TryParse(heightTextBox.Text.Trim(), out value))
            {
                if (bmiCalculator.GetUnit() == BmiCalculator.Unit.METRIC)
                    value = value / 100;    // convert cm to m

                bmiCalculator.SetHeight(value);
            }
            else
                return false;

            // Read weight
            value = 0;
            if (double.TryParse(weightTextBox.Text.Trim(), out value))
                bmiCalculator.SetWeight(value);
            else
                return false;

            return true;
        }

        /* Update the labels concering the results of the BMI calculation */
        private void updateBmiResults()
        {
            bmiResultsGroupBox.Text = "Results for " + name;
            bmiLabel.Text = bmiCalculator.GetBMI().ToString("0.00");
            bmiWeightCategoryLabel.Text = bmiCalculator.GetWeightCategory();
        }

        /* Shows a message box */
        private void showErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        /* 
         * Change the labels' text depending when the usUnitRadioButton changes checked 
         * state. 
         */
        private void usUnitRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (usUnitRadioButton.Checked)
            {
                bmiHeightLabel.Text = "Height (inches)";
                bmiWeightLabel.Text = "Weight (lbs)";
            }
            else
            {
                bmiHeightLabel.Text = "Height (cm)";
                bmiWeightLabel.Text = "Weight (kg)";
            }
        }
    }
}
