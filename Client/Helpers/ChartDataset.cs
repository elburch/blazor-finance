namespace BlazorFinance.Client.Helpers
{
    public class ChartDataset
    {
        public string Label { get; set; } = string.Empty;
        public string[] BackgroundColor { get; set; } = new string[] { };
        public string BorderColor { get; set; } = string.Empty;
        public string[] Data { get; set; } = new string[] { };
    }
}
