using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;

namespace GoatAutoCAD.baseutil {

    public class FilterList {

        private readonly List<TypedValue> Cache = new List<TypedValue>();

        public static FilterList Create() {
            return new FilterList();
        }

        /// <summary>
        /// Gets the TypedValue array representation.
        /// </summary>
        /// <returns>The array.</returns>
        public TypedValue[] ToArray() {
            return Cache.ToArray();
        }

        /// <summary>
        /// Adds a DXF type filter.
        /// </summary>
        /// <param name="dxfTypes">The DXF types.</param>
        /// <returns>The helper.</returns>
        public FilterList DxfType(params string[] dxfTypes)
        {
            Cache.Add(new TypedValue((int)DxfCode.Start, string.Join(",", dxfTypes)));
            return this;
        }

        /// <summary>
        /// Adds a layer filter.
        /// </summary>
        /// <param name="layers">The layers.</param>
        /// <returns>The helper.</returns>
        public FilterList Layer(string[] layers){
            Cache.Add(new TypedValue((int)DxfCode.LayerName, string.Join(",", layers)));
            return this;
        }

        /// <summary>
        /// Adds an arbitrary filter.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        /// <param name="value">The value.</param>
        /// <returns>The helper.</returns>
        public FilterList Filter(int typeCode, string value)
        {
            this.Cache.Add(new TypedValue(typeCode, value));
            return this;
        }
    }
}