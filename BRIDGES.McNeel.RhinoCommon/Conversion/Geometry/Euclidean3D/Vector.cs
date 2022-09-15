using System;
using System.Collections.Generic;

using RH_Geo = Rhino.Geometry;

using Euc3D = BRIDGES.Geometry.Euclidean3D;
using Rhino.Commands;


namespace BRIDGES.McNeel.RhinoCommon.Conversion.Geometry.Euclidean3D
{
    /// <summary>
    /// Class defining conversion between <see cref="Euc3D.Vector"/> and <see cref="RH_Geo.Vector3d"/>
    /// </summary>
    public static class Vector
    {
        /******************** Item ********************/

        /// <summary>
        /// Converts a <see cref="Euc3D.Vector"/> to a <see cref="RH_Geo.Vector3d"/>.
        /// </summary>
        /// <param name="point"> The <see cref="Euc3D.Vector"/> to convert. </param>
        /// <returns> The new <see cref="RH_Geo.Vector3d"/>.</returns>
        public static RH_Geo.Vector3d ConvertToRhino(this Euc3D.Vector point)
        {
            return new RH_Geo.Vector3d(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Converts a <see cref="RH_Geo.Vector3d"/> to a <see cref="Euc3D.Vector"/>.
        /// </summary>
        /// <param name="point"> The <see cref="RH_Geo.Vector3d"/> to convert.</param>
        /// <returns> The new <see cref="Euc3D.Vector"/>.</returns>
        public static Euc3D.Vector ConvertFromRhino(this RH_Geo.Vector3d point)
        {
            return new Euc3D.Vector(point.X, point.Y, point.Z);
        }


        /******************** Array ********************/

        /// <summary>
        /// Converts an array of <see cref="Euc3D.Vector"/> to an array of <see cref="RH_Geo.Vector3d"/>.
        /// </summary>
        /// <param name="points"> The array of <see cref="Euc3D.Vector"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="RH_Geo.Vector3d"/>. </returns>
        public static RH_Geo.Vector3d[] ConvertToRhino(this Euc3D.Vector[] points)
        {
            RH_Geo.Vector3d[] result = new RH_Geo.Vector3d[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = new RH_Geo.Vector3d(points[i].X, points[i].Y, points[i].Z);
            }
            return result;
        }

        /// <summary>
        /// Casts an array of <see cref="RH_Geo.Vector3d"/> to an array of <see cref="Euc3D.Vector"/>.
        /// </summary>
        /// <param name="points"> The array of <see cref="RH_Geo.Vector3d"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="Euc3D.Vector"/>.</returns>
        public static Euc3D.Vector[] ConvertFromRhino(this RH_Geo.Vector3d[] points)
        {
            Euc3D.Vector[] result = new Euc3D.Vector[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = new Euc3D.Vector(result[i].X, result[i].Y, result[i].Z);
            }
            return result;
        }


        /******************** List ********************/

        /// <summary>
        /// Converts a list of <see cref="Euc3D.Vector"/> to a list of <see cref="RH_Geo.Vector3d"/>.
        /// </summary>
        /// <param name="points"> The list of <see cref="Euc3D.Vector"/> to convert. </param>
        /// <returns> The new list of <see cref="RH_Geo.Vector3d"/>. </returns>
        public static List<RH_Geo.Vector3d> ConvertToRhino(this List<Euc3D.Vector> points)
        {
            List<RH_Geo.Vector3d> result = new List<RH_Geo.Vector3d>(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new RH_Geo.Vector3d(points[i].X, points[i].Y, points[i].Z));
            }
            return result;
        }

        /// <summary>
        /// Casts a list of <see cref="RH_Geo.Vector3d"/> to a list of <see cref="Euc3D.Vector"/>.
        /// </summary>
        /// <param name="points"> The list of <see cref="RH_Geo.Vector3d"/> to convert. </param>
        /// <returns> The corresponding list of <see cref="Euc3D.Vector"/>. </returns>
        public static List<Euc3D.Vector> ConvertFromRhino(this List<RH_Geo.Vector3d> points)
        {
            List<Euc3D.Vector> result = new List<Euc3D.Vector>(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new Euc3D.Vector(points[i].X, points[i].Y, points[i].Z));
            }
            return result;
        }
    }
}
