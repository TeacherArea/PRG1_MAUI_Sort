namespace PRG1_MAUI_Sort
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        double[] unsortedList = null;
        double[] sortedList = null;

        public MainPage()
        {
            InitializeComponent();
        }

        private void SortNumbers(object sender, EventArgs e)
        {
            if (int.TryParse(NumbersEntry.Text, out int amount))
            {
                if (amount <= 0)
                {
                    UnsortedLabel.Text = "Vänligen skriv in ett positivt heltal!";
                    return;
                }

                unsortedList = new double[amount];
                for (int i = 0; i < unsortedList.Length; i++)
                {
                    unsortedList[i] = random.NextDouble() * 100;
                }

                double[] roundedUnsortedList = RoundValues(unsortedList);
                UnsortedLabel.Text = $"Osorterade värden\n{string.Join(", ", roundedUnsortedList)}";

                sortedList = BubbleSort(unsortedList);
                double[] roundedSortedList = RoundValues(sortedList);
                SortedLabel.Text = $"Sorterade värden\n{string.Join(", ", roundedSortedList)}";
            }
            else
            {
                UnsortedLabel.Text = "Vänligen skriv in ett giltigt heltal!";
            }
        }

        private double[] RoundValues(double[] array)
        {
            double[] roundedArray = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                roundedArray[i] = Math.Round(array[i], 2);
            }
            return roundedArray;
        }

        private double[] BubbleSort(double[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
    }
}
