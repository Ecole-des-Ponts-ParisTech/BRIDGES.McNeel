using System;
using System.Collections.Generic;

using RH_Geo = Rhino.Geometry;

using Euc3D = BRIDGES.Geometry.Euclidean3D;


namespace BRIDGES.McNeel.RhinoCommon.Conversion.Geometry.Euclidean3D
{
    /// <summary>
    /// Class defining conversion between <see cref="Euc3D.Point"/> and <see cref="RH_Geo.Point3d"/>
    /// </summary>
    public static class Point
    {
        /******************** Item ********************/

        /// <summary>
        /// Converts a <see cref="Euc3D.Point"/> to a <see cref="RH_Geo.Point3d"/>.
        /// </summary>
        /// <param name="point"> The <see cref="Euc3D.Point"/> to convert. </param>
        /// <returns> The new <see cref="RH_Geo.Point3d"/>.</returns>
        public static RH_Geo.Point3d ConvertToRhino(this Euc3D.Point point)
        {
            return new RH_Geo.Point3d(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Converts a <see cref="RH_Geo.Point3d"/> to a <see cref="Euc3D.Point"/>.
        /// </summary>
        /// <param name="point"> The <see cref="RH_Geo.Point3d"/> to convert.</param>
        /// <returns> The new <see cref="Euc3D.Point"/>.</returns>
        public static Euc3D.Point ConvertFromRhino(this RH_Geo.Point3d point)
        {
            return new Euc3D.Point(point.X, point.Y, point.Z);
        }


        /******************** Array ********************/

        /// <summary>
        /// Converts an array of <see cref="Euc3D.Point"/> to an array of <see cref="RH_Geo.Point3d"/>.
        /// </summary>
        /// <param name="points"> The array of <see cref="Euc3D.Point"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="RH_Geo.Point3d"/>. </returns>
        public static RH_Geo.Point3d[] ConvertToRhino(this Euc3D.Point[] points)
        {
            RH_Geo.Point3d[] result = new RH_Geo.Point3d[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = new RH_Geo.Point3d(points[i].X, points[i].Y, points[i].Z);
            }
            return result;
        }

        /// <summary>
        /// Casts an array of <see cref="RH_Geo.Point3d"/> to an array of <see cref="Euc3D.Point"/>.
        /// </summary>
        /// <param name="points"> The array of <see cref="RH_Geo.Point3d"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="Euc3D.Point"/>.</returns>
        public static Euc3D.Point[] ConvertFromRhino(this RH_Geo.Point3d[] points)
        {
            Euc3D.Point[] result = new Euc3D.Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = new Euc3D.Point(result[i].X, result[i].Y, result[i].Z);
            }
            return result;
        }


        /******************** List ********************/

        /// <summary>
        /// Converts a list of <see cref="Euc3D.Point"/> to a list of <see cref="RH_Geo.Point3d"/>.
        /// </summary>
        /// <param name="points"> The list of <see cref="Euc3D.Point"/> to convert. </param>
        /// <returns> The new list of <see cref="RH_Geo.Point3d"/>. </returns>
        public static List<RH_Geo.Point3d> ConvertToRhino(this List<Euc3D.Point> points)
        {
            List<RH_Geo.Point3d> result = new List<RH_Geo.Point3d>(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new RH_Geo.Point3d(points[i].X, points[i].Y, points[i].Z));
            }
            return result;
        }

        /// <summary>
        /// Casts a list of <see cref="RH_Geo.Point3d"/> to a list of <see cref="Euc3D.Point"/>.
        /// </summary>
        /// <param name="points"> The list of <see cref="RH_Geo.Point3d"/> to convert. </param>
        /// <returns> The corresponding list of <see cref="Euc3D.Point"/>. </returns>
        public static List<Euc3D.Point> ConvertFromRhino(this List<RH_Geo.Point3d> points)
        {
            List<Euc3D.Point> result = new List<Euc3D.Point>(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new Euc3D.Point(points[i].X, points[i].Y, points[i].Z));
            }
            return result;
        }
    }
}
