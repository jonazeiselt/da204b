/**
 * Class dealing with the gas consumption calculations of the 
 * main form. 
 * Created by Jonas Eiselt on 2018-10-23.
 */
namespace Assignment3
{
    public class FuelCalculator
    {
        public enum Unit
        {
            KM_PER_LITER,
            LITERS_PER_KM,
            LITERS_PER_METRIC_MILE,
            LITERS_PER_10_KM
        }

        private double currentReading;
        private double previousReading;
        private double fuelAmountTanked;
        private double pricePerLiter;

        /* Set method for currentReading */
        public void SetCurrentReading(double currentReading)
        {
            this.currentReading = currentReading;
        }

        /* Set method for previousReading */
        public void SetPreviousReading(double previousReading)
        {
            this.previousReading = previousReading;
        }

        /* Set method for fuelAmountTanked */
        public void SetFuelAmountTanked(double fuelAmountTanked)
        {
            this.fuelAmountTanked = fuelAmountTanked;
        }
        
        /* Set method for pricePerLiter */
        public void SetPricePerLiter(double pricePerLiter)
        {
            this.pricePerLiter = pricePerLiter;
        }

        /* Calculate gas consumption based on the desired unit */
        public double CalculateFuelConsumption(Unit unit)
        {
            double kmDifference = calculateKilometerDifference();
            if (unit == Unit.KM_PER_LITER)
                return calculateKilometersPerLiter(kmDifference);
            else if (unit == Unit.LITERS_PER_KM)
                return calculateLitersPerKilometer(kmDifference);
            else if (unit == Unit.LITERS_PER_METRIC_MILE)
                return calculateLitersPerMetricMile(kmDifference);
            else if (unit == Unit.LITERS_PER_10_KM)
                return calculateLitersPer10Kilometer(kmDifference);
            
            return 0;
        }

        private double calculateKilometerDifference()
        {
            return currentReading - previousReading;
        }

        /* Calculate the gas consumption (liters per km) */
        private double calculateLitersPerKilometer(double kmDifference)
        {
            return fuelAmountTanked / kmDifference;
        }

        /* Calculate how many km can be driven per liter */
        private double calculateKilometersPerLiter(double kmDifference)
        {
            return kmDifference / fuelAmountTanked;
        }

        /* Calculate the gas consumption (liters per (US) mile) */
        private double calculateLitersPerMetricMile(double kmDifference)
        {
            const double kmPerMile = 0.621371192;
            return calculateLitersPerKilometer(kmDifference) / kmPerMile;
        }

        /* Calculate the gas consumption (liters per 10 km) */
        private double calculateLitersPer10Kilometer(double kmDifference)
        {
            return calculateLitersPerKilometer(kmDifference) * 10;
        }
        
        public double CalculateCostPerKm()
        {
            double kmDifference = calculateKilometerDifference();
            return calculateLitersPerKilometer(kmDifference) * pricePerLiter;
        }

        /* 
         * Return true if current reading is greater than previous reading 
         * and the previous reading is greater than or equal to 0
         */
        public bool ValidateOdometerValues()
        {
            return currentReading > previousReading && previousReading >= 0;
        }

        /*
         * Return true if price per liter is a positive number
         */ 
        public bool ValidatePricePerLiterValue()
        {
            return pricePerLiter >= 0;
        }
    }
}