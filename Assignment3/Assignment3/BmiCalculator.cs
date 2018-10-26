using System;

/**
 * Class dealing with the BMI calculations of the main form.
 * Created by Jonas Eiselt on 2018-10-23. 
 */
namespace Assignment3
{
    public class BmiCalculator
    {
        private Unit unit;
        public enum Unit
        {
            METRIC, US
        }
        
        private double height;
        private double weight;
        private double bmi;

        /* Get method for unit */
        public Unit GetUnit()
        {
            return unit;
        }

        /* Set method for unit */
        public void SetUnit(Unit unit)
        {
            this.unit = unit;
        }

        /* Set method for height */
        public void SetHeight(double height)
        {
            this.height = height;
        }

        /* Set method for weight */
        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        /* 
         * Calculates BMI using metric units (kg, m) or using US units (lbs, 
         * inch). Calculates BMI using US units if the enum variable unitType is set 
         * to US. 
         */
        public void Calculate()
        {
            if (unit == Unit.METRIC)
                bmi = weight / Math.Pow(height, 2);
            else
                bmi = 703.0 * weight / Math.Pow(height, 2);
        }

        /* Get method for bmi */
        public double GetBMI()
        {
            return bmi;
        }
        
        /* 
         * Returns the calculated BMI's corresponding weight category. Weight
         * categories are based on recommendations from the World Health 
         * Organization. 
         */
        public string GetWeightCategory()
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 24.9)
                return "Normal weight";
            else if (bmi < 29.9)
                return "Overweight";
            else if (bmi < 34.9)
                return "Obesity, class I";
            else if (bmi < 39.9)
                return "Obesity, class II";
            else
                return "Obesity, class III";
        }
    }
}