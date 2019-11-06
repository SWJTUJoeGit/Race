# PolygonOnMap

In order to run this code you should

-install nuget ArcGISRuntime packages

-download Luxembourg map (https://esrisoftware.esri.com/akdlm/software/StreetMap_HERE/2017R2/Navigator/Europe/Luxembourg.mmpk)

-change code in the file "MainWindow.xaml.cs"(
MobileMapPackage.OpenAsync("C:\\Users\\Steve\\Downloads\\Luxembourg.xml");
to
MobileMapPackage.OpenAsync({file path of Luxembourg map});
)
