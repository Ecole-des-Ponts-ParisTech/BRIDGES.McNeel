using System;
using System.Collections.Generic;

using RH_Geo = Rhino.Geometry;

using Euc3D = BRIDGES.Geometry.Euclidean3D;


namespace BRIDGES.McNeel.RhinoCommon.Conversion.Geometry.Euclidean3D
{
    /// <summary>
    /// Class defining conversion between <see cref="Euc3D.Polyline"/> and <see cref="RH_Geo.Polyline"/>
    /// </summary>
    public static class Polyline
    {
        /******************** Item ********************/

        /// <summary>
        /// Converts a <see cref="Euc3D.Polyline"/> to a <see cref="RH_Geo.Polyline"/>.
        /// </summary>
        /// <param name="polyline"> The <see cref="Euc3D.Polyline"/> to convert. </param>
        /// <returns> The new <see cref="RH_Geo.Polyline"/>.</returns>
        public static RH_Geo.Polyline ConvertToRhino(this Euc3D.Polyline polyline)
        {
            RH_Geo.Point3d[] vertices = new RH_Geo.Point3d[polyline.VertexCount];
            for (int i = 0; i < polyline.VertexCount; i++)
            {
                vertices[i] = polyline[i].ConvertToRhino();
            }

            return new RH_Geo.Polyline(vertices);
        }

        /// <summary>
        /// Converts a <see cref="RH_Geo.Polyline"/> to a <see cref="Euc3D.Polyline"/>.
        /// </summary>
        /// <param name="polyline"> The <see cref="RH_Geo.Polyline"/> to convert.</param>
        /// <returns> The new <see cref="Euc3D.Polyline"/>.</returns>
        public static Euc3D.Polyline ConvertFromRhino(this RH_Geo.Polyline polyline)
        {
            Euc3D.Point[] vertices = new Euc3D.Point[polyline.Count];
            for (int i = 0; i < polyline.Count; i++)
            {
                vertices[i] = polyline[i].ConvertFromRhino();
            }

            return new Euc3D.Polyline(vertices, polyline.IsClosed);
        }


        /******************** Array ********************/

        /// <summary>
        /// Converts an array of <see cref="Euc3D.Polyline"/> to an array of <see cref="RH_Geo.Polyline"/>.
        /// </summary>
        /// <param name="polylines"> The array of <see cref="Euc3D.Polyline"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="RH_Geo.Polyline"/>. </returns>
        public static RH_Geo.Polyline[] ConvertToRhino(this Euc3D.Polyline[] polylines)
        {
            RH_Geo.Polyline[] result = new RH_Geo.Polyline[polylines.Length];
            for (int i = 0; i < polylines.Length; i++)
            {
                result[i] = polylines[i].ConvertToRhino();
            }
            return result;
        }

        /// <summary>
        /// Casts an array of <see cref="RH_Geo.Polyline"/> to an array of <see cref="Euc3D.Polyline"/>.
        /// </summary>
        /// <param name="polylines"> The array of <see cref="RH_Geo.Polyline"/> to cast.</param>
        /// <returns> The corresponding array of <see cref="Euc3D.Polyline"/>.</returns>
        public static Euc3D.Polyline[] ConvertFromRhino(this RH_Geo.Polyline[] polylines)
        {
            Euc3D.Polyline[] result = new Euc3D.Polyline[polylines.Length];
            for (int i = 0; i < polylines.Length; i++)
            {
                result[i] = polylines[i].ConvertFromRhino();
            }
            return result;
        }


        /******************** List ********************/

        /// <summary>
        /// Converts a list of <see cref="Euc3D.Polyline"/> to a list of <see cref="RH_Geo.Polyline"/>.
        /// </summary>
        /// <param name="polylines"> The list of <see cref="Euc3D.Polyline"/> to convert. </param>
        /// <returns> The new list of <see cref="RH_Geo.Polyline"/>. </returns>
        public static List<RH_Geo.Polyline> ConvertToRhino(this List<Euc3D.Polyline> polylines)
        {
            List<RH_Geo.Polyline> result = new List<RH_Geo.Polyline>(polylines.Count);
            for (int i = 0; i < polylines.Count; i++)
            {
                result[i] = polylines[i].ConvertToRhino();
            }
            return result;
        }

        /// <summary>
        /// Casts a list of <see cref="RH_Geo.Polyline"/> to a list of <see cref="Euc3D.Polyline"/>.
        /// </summary>
        /// <param name="polylines"> The list of <see cref="RH_Geo.Polyline"/> to convert. </param>
        /// <returns> The corresponding list of <see cref="Euc3D.Polyline"/>. </returns>
        public static List<Euc3D.Polyline> ConvertFromRhino(this List<RH_Geo.Polyline> polylines)
        {
            List<Euc3D.Polyline> result = new List<Euc3D.Polyline>(polylines.Count);
            for (int i = 0; i < polylines.Count; i++)
            {
                result[i] = polylines[i].ConvertFromRhino();
            }
            return result;
        }
    }
}
