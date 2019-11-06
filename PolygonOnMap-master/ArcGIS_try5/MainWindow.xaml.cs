using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;

namespace ArcGIS_try5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MapInitialize();
        }

        // create a new graphics overlay
        private GraphicsOverlay MyGraphicsOverlay = new GraphicsOverlay();

        // use a polygon builder to create a new polygon from a collection of points
        private PolygonBuilder polygonBuilder = new PolygonBuilder(SpatialReferences.Wgs84);

        private async void MapInitialize()
        {
            // Open a StreetMap Premium mobile map package from local src
            // if you want to run this application you should change path to online src or local one
            MobileMapPackage indianaPackage = await MobileMapPackage.OpenAsync("C:\\Users\\Steve\\Downloads\\Luxembourg.xml");
            // Get the first map
            Map navigationMap = indianaPackage.Maps[0];            
            // Add it to the map view
            MyMapView.Map = navigationMap;

            // add the overlay to the map view's graphics overlay collection
            MyMapView.GraphicsOverlays.Add(MyGraphicsOverlay);

            //// Create new Map with basemap
            //Map myMap = new Map(Basemap.CreateStreetsVector());
            //myMap.InitialViewpoint = new Viewpoint(41, 69, 4000000);
            //// Assign the map to the MapView,
            //MyMapView.Map = myMap;
        }

        private void GeoViewTapped(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            //checking for ViewPoint Initializetion if not it does nothing
            if (MyMapView.GetCurrentViewpoint(ViewpointType.BoundingGeometry) == null)
                return;

            var holdPt = new MapPoint(e.Location.X, e.Location.Y, MyMapView.SpatialReference);
            var mapPt = (MapPoint)GeometryEngine.Project(holdPt, SpatialReferences.Wgs84);
            //MessageBox.Show(mapPt.ToString());
            var buoyMarker = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, Colors.Red, 3);
            var buoyGraphic = new Graphic(mapPt, buoyMarker);
            //add the point graphic
            MyGraphicsOverlay.Graphics.Add(buoyGraphic);
            
            // add points to the polygon builder
            polygonBuilder.AddPoint(mapPt);

        }
        
        private void MouseRightBtnDown(object sender, MouseButtonEventArgs e)
        {
            // get the polygon from the polygon builder
            var nestingGround = polygonBuilder.ToGeometry();
            // define the polygon outline
            var outlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
            // define the fill symbol
            var fillSymbol = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(255, 0, 80, 0), outlineSymbol);
            // create the graphic
            var nestingGraphic = new Graphic(nestingGround, fillSymbol);
            // add the polygon graphic
            MyGraphicsOverlay.Graphics.Add(nestingGraphic);
            polygonBuilder = new PolygonBuilder(SpatialReferences.Wgs84);
        }
    }
}
