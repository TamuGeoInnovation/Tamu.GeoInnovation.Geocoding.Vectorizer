using AssessorLib;
using System;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Geometries.Polygons;

namespace USC.GISResearchLab.Geocoding.Vectorizing
{
    public class Vectorizer
    {

        public static Polygon VectorizeSpecificPolygon(string uri, int x, int y)
        {
            Assessor asr = new Assessor(uri);
            GeoLib.Polygon polygon = asr.RunSingle2(x, y);

            Polygon ret = new Polygon();

            ret.Area = polygon.area;
            ret.Cx = polygon.cx;
            ret.Cy = polygon.cy;
            ret.Id = polygon.ID;
            ret.NumParts = polygon.NumParts;
            ret.NumPoints = polygon.NumPoints;
            ret.Parts = polygon.Parts;
            ret.Points = new Point[polygon.Points.Length];

            for (int i = 0; i < polygon.Points.Length; i++)
            {
                Point p = new Point();

                p.Id = polygon.Points[i].ID;
                p.X = polygon.Points[i].X;
                p.Y = polygon.Points[i].Y;

                ret.Points[i] = p;

            }


            return ret;

        }

        public static Polygon Vectorize(string uri)
        {
            Polygon ret = null;
            try
            {

                Assessor asr = new Assessor(uri);
                GeoLib.Polygon polygon = asr.RunSingle();
                ret = new Polygon();

                ret.Area = polygon.area;
                ret.Cx = polygon.cx;
                ret.Cy = polygon.cy;
                ret.Id = polygon.ID;
                ret.NumParts = polygon.NumParts;
                ret.NumPoints = polygon.NumPoints;
                ret.Parts = polygon.Parts;
                ret.Points = new Point[polygon.Points.Length];

                for (int i = 0; i < polygon.Points.Length; i++)
                {
                    Point p = new Point();

                    p.Id = polygon.Points[i].ID;
                    p.X = polygon.Points[i].X;
                    p.Y = polygon.Points[i].Y;

                    ret.Points[i] = p;

                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred running the vectorizer ", e);
            }
            return ret;
        }
    }
}
