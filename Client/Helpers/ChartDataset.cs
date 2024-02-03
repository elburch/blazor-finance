namespace BlazorFinance.Client.Helpers
{
    public class ChartDataset
    {
        public string Label { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;
        public string BorderColor { get; set; } = string.Empty;
        public string[] Data { get; set; } = new string[] { };
    }
}
