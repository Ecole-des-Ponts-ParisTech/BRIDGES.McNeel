using System;
using System.Drawing;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using BRIDGES.McNeel.RhinoCommon.Conversion.Geometry.Euclidean3D;

using RH_Geo = Rhino.Geometry;
using RH_Disp = Rhino.Display;

using GH = Grasshopper;
using GH_Kernel = Grasshopper.Kernel;
using GH_Types = Grasshopper.Kernel.Types;


namespace ENPC.McNeel.Grasshopper.Types.Geometry.Euclidean3D
{
    /// <summary>
    /// Class defining a grasshopper type for an <see cref="Euc3D.Point"/> .
    /// </summary>
    public class Gh_Point : GH_Types.GH_Goo<Euc3D.Point>, GH_Kernel.IGH_PreviewData
    {
        #region Properties
        
        /// <summary>
        /// Volume containing the data.
        /// </summary>
        public RH_Geo.BoundingBox Boundingbox
        {
            get
            {
                RH_Geo.Point3d point = this.Value.ConvertToRhino();
                return new RH_Geo.BoundingBox(point, point);
            }
        }

        /// <inheritdoc cref="GH_Kernel.IGH_PreviewData.ClippingBox"/>
        public RH_Geo.BoundingBox ClippingBox
        {
            get { return this.Boundingbox; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of <see cref= "Gh_Point" /> class.
        /// </summary>
        public Gh_Point() { }

        /// <summary>
        /// Initialises a new instance of <see cref= "Gh_Point" /> class from another <see cref="Gh_Point"/>..
        /// </summary>
        /// <param name="gh_Point"> <see cref="Gh_Point"/> to duplicate. </param>
        public Gh_Point(Gh_Point gh_Point)
        {
            this.Value = new Euc3D.Point(gh_Point.Value);
        }

        /// <summary>
        /// Initialises a new instance of <see cref="Gh_Point"/> class from a <see cref="Euc3D.Point"/>.
        /// </summary>
        /// <param name="point"> <see cref="Euc3D.Point"/> to duplicate.</param>
        public Gh_Point(Euc3D.Point point)
        {
            this.Value = new Euc3D.Point(point);
        }

        #endregion

        #region Methods

        /// <inheritdoc cref="GH_Kernel.IGH_PreviewData.DrawViewportMeshes(GH_Kernel.GH_PreviewMeshArgs)"/>
        public void DrawViewportMeshes(GH_Kernel.GH_PreviewMeshArgs args)
        {
            /* Do nothing */
        }

        /// <inheritdoc cref="GH_Kernel.IGH_PreviewData.DrawViewportWires(GH_Kernel.GH_PreviewWireArgs)"/>
        public void DrawViewportWires(GH_Kernel.GH_PreviewWireArgs args)
        {
            DrawPoint(args.Pipeline, 5, args.Color);
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Draws a point in the rhino viewport.
        /// </summary>
        /// <param name="display"> The Rhino helper for diplaying objects. </param>
        /// <param name="radius"> The radius of the point displayed. </param>
        /// <param name="color"> The color of the point to display. </param>
        internal void DrawPoint(RH_Disp.DisplayPipeline display, int radius, Color color)
        {
            RH_Disp.PointStyle previewPointStyle = GH.CentralSettings.PreviewPointStyle;
            display.DrawPoint(this.Value.ConvertToRhino(), previewPointStyle, radius, color);
        }

        #endregion


        #region Override : GH_Goo<>

        /********** Properties **********/

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.IsValid"/>
        public override bool IsValid { get { return true; } }

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.TypeDescription"/>
        public override string TypeDescription { get { return String.Format($"({Value.X},{Value.Y},{Value.Z})"); } }

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.TypeName"/>
        public override string TypeName { get { return "Gh_Point"; } }


        /********** Methods **********/

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.ToString"/>
        public override string ToString()
        {
            return string.Format($"An {nameof(Gh_Point)} at ({Value.X},{Value.Y},{Value.Z})");
        }

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.Duplicate"/>
        public override GH_Types.IGH_Goo Duplicate()
        {
            return new Gh_Point(this);
        }


        /// <inheritdoc cref="GH_Types.GH_Goo{T}.CastFrom(object)"/>
        public override bool CastFrom(object source)
        {
            if (source == null) { return false; }

            var type = source.GetType();

            /******************** For Points ********************/

            // Cast a Euc3D.Point to a Gh_Point
            if (type == typeof(Euc3D.Point))
            {
                this.Value = (Euc3D.Point)source;
                return true;
            }
            // Casts a GH_Types.GH_Point to a Gh_Point
            if (type == typeof(GH_Types.GH_Point))
            {
                RH_Geo.Point3d rh_Point = ((GH_Types.GH_Point)source).Value;
                this.Value = rh_Point.ConvertFromRhino();
                return true;
            }
            // Casts a RH_Geo.Point3d to a Gh_Point
            if (type == typeof(RH_Geo.Point3d))
            {
                RH_Geo.Point3d rh_Point = (RH_Geo.Point3d)source;
                this.Value = rh_Point.ConvertFromRhino();
                return true;
            }


            /******************** For Vectors ********************/

            // Cast a Euc3D.Vector to a Gh_Point
            if (type == typeof(Euc3D.Vector))
            {
                this.Value = (Euc3D.Point)source;
                return true;
            }
            // Casts a GH_Types.GH_Vector to a Gh_Point
            if (type == typeof(GH_Types.GH_Vector))
            {
                RH_Geo.Vector3d rh_Point = ((GH_Types.GH_Vector)source).Value;
                this.Value = (Euc3D.Point) (rh_Point.ConvertFromRhino());
                return true;
            }
            // Casts a RH_Geo.Point3d to a Gh_Point
            if (type == typeof(RH_Geo.Vector3d))
            {
                RH_Geo.Point3d rh_Point = (RH_Geo.Point3d)source;
                this.Value = rh_Point.ConvertFromRhino();
                return true;
            }


            /******************** Otherwise ********************/

            return false;
        }

        /// <inheritdoc cref="GH_Types.GH_Goo{T}.CastTo{Q}(ref Q)"/>
        public override bool CastTo<T>(ref T target)
        {
            /******************** For Points ********************/

            // Casts a Gh_Point to a Euc3D.Point
            if (typeof(T).IsAssignableFrom(typeof(Euc3D.Point)))
            {
                object point = this.Value;
                target = (T)point;
                return true;
            }
            // Casts a Gh_Point to a RH_Geo.Point3d
            if (typeof(T).IsAssignableFrom(typeof(RH_Geo.Point3d)))
            {
                object rh_Point = this.Value.ConvertToRhino();
                target = (T)rh_Point;
                return true;
            }
            // Casts a Gh_Point to a GH_Types.GH_Point
            if (typeof(T).IsAssignableFrom(typeof(GH_Types.GH_Point)))
            {
                object gh_Point = new GH_Types.GH_Point(this.Value.ConvertToRhino());
                target = (T)gh_Point;
                return true;
            }


            /******************** For Vectors ********************/

            // Casts a Gh_Point to a Euc3D.Vector
            if (typeof(T).IsAssignableFrom(typeof(Euc3D.Vector)))
            {
                object vector = this.Value;
                target = (T)vector;
                return true;
            }
            // Casts a Gh_Point to a RH_Geo.Vector3d
            if (typeof(T).IsAssignableFrom(typeof(RH_Geo.Vector3d)))
            {
                object rh_Vector = this.Value.ConvertToRhino();
                target = (T)rh_Vector;
                return true;
            }
            // Casts a Gh_Point to a GH_Types.GH_Vector
            if (typeof(T).IsAssignableFrom(typeof(GH_Types.GH_Vector)))
            {
                object gh_Vector = new GH_Types.GH_Vector(((Euc3D.Vector)this.Value).ConvertToRhino());
                target = (T)gh_Vector;
                return true;
            }


            /******************** Otherwise ********************/

            return false;
        }

        #endregion
    }
}
