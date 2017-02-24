﻿namespace ThirtyRails.Logic
{
    public class StationTile : Tile
    {
        public StationTile(int id) : base(id)
        {
        }

        public bool IsStation { get; set; }
        public bool PreviewStation { get; set; }
        public bool IsHorizontal => Y == 0 || Y == 7;
    }
}