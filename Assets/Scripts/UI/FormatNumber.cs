namespace UI
{
    public static class FormatNumber
    {
        public static string FormatDouble(double num)
        {
            return num switch
            {
                >= 100000000 => (num / 1000000).ToString("#,0M"),
                >= 10000000 => (num / 1000000).ToString("0.#") + "M",
                >= 100000 => (num / 1000).ToString("#,0K"),
                >= 10000 => (num / 1000).ToString("0.#") + "K",
                _ => num.ToString("#,0")
            };
        }
    }
}