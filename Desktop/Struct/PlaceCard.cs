namespace LoRHelper.Struct
{
    //Struct complement for State Game.
    struct PlaceCard
    {
        //Json vars.
        public ulong CardID { get; set; }
        public string CardCode { get; set; }
        public ushort Height { get; set; }
        public ushort TopLeftY { get; set; }
        public bool LocalPlayer { get; set; }
    }
}
