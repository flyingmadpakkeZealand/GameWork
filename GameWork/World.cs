using System;
using System.Collections.Generic;
using System.Text;
using XmlFramework;

namespace GameWork
{
    public abstract class World
    {
        public int Height { get; set; }
        public int Width { get; set; }

        protected World(int height, int width)
        {
            Height = height;
            Width = width;

            PopulateWorld();
        }

        protected World()
        {
            XmlLayer root = XmlLayer.CreateRootLayer(PlaceHolderFileSystem.ConfigFilePath);
            Extraction extractionWorldSize = Extraction.OnMany(WorldSizeRoute)
                .OnNone(() => {Height = 100; Width = 100;});

            root.ExtractIntoFromElements(extractionWorldSize, "World");
            root.Dispose();

            PopulateWorld();
        }

        private void WorldSizeRoute(List<XmlData> dataListed)
        {
            XmlData data = dataListed[0];
            switch (data.Source.ToLower())
            {
                case "height": Height = Convert.ToInt32(data.Data); return;
                case "width": Width = Convert.ToInt32(data.Data); return;
            }
        }

        protected abstract void PopulateWorld();
    }
}
