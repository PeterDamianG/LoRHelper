namespace LoRHelper.Struct
{
    //Struct principal to save cards.
    public struct Card
    {
        //Json vars.
        public ulong CardID { get; set; }
        public byte Cost { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}