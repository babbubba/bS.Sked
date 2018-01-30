namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IDescribedEntity
    {
        /// <summary>
        /// Gets or sets the friendly name for the object.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets a short description for the object.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}
