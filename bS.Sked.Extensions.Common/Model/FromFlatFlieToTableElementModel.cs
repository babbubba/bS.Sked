using System;
using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;

namespace bS.Sked.Extensions.Common.Model
{
    /// <summary>
    /// The FromFlatFlieToTable element model
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Elements.Base.ExecutableElementBaseModel" />
    /// <seealso cref="bS.Sked.Model.Interfaces.Elements.Properties.IInputFileObject" />
    /// <seealso cref="bS.Sked.Model.Interfaces.Elements.Properties.IOutputTableObject" />
    public class FromFlatFlieToTableElementModel : ExecutableElementBaseModel, IInputFileObject, IOutputTableObject
    {
        /// <summary>
        /// Gets or sets how many starting data rows to skip (default: no row will be skipped).
        /// </summary>
        /// <value>
        /// The skip starting data rows.
        /// </value>
        public virtual int SkipStartingDataRows { get; set; }
        /// <summary>
        /// Gets or sets the separator value for columns in flat file.
        /// </summary>
        /// <value>
        /// The separator value.
        /// </value>
        public virtual char? SeparatorValue { get; set; }
        /// <summary>
        /// Gets or sets mow many data rows to read.
        /// </summary>
        /// <value>
        /// The limit to rows.
        /// </value>
        public virtual int LimitToRows { get; set; }
        /// <summary>
        /// Gets a value indicating whether [first row has the header] for output table.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [first row has header]; otherwise, <c>false</c>.
        /// </value>
        public bool FirstRowHasHeader { get; internal set; }



        #region Properties
        public virtual IFileObject InFileObject { get; set; }
        public virtual ITableObject OutTableObject { get; set; }
        #endregion
    }

    class FromFlatFlieToTableElementModelMap : SubclassMap<FromFlatFlieToTableElementModel>
    {
        public FromFlatFlieToTableElementModelMap()
        {
            DiscriminatorValue(StaticContent.fromFlatFlieToTable);
            Map(x => x.SkipStartingDataRows);
            Map(x => x.SeparatorValue);
            Map(x => x.LimitToRows);
            Map(x => x.FirstRowHasHeader);
            References<FileSystemFileModel>(x => x.InFileObject).Cascade.All();
        }
    }

}
