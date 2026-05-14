namespace first_app_api.data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public IList<Hotel> Hotels { get; set; }
    }
}
