using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SmartStore.Core.Domain.Catalog;

namespace SmartStore.Core.Domain.Media
{
	[DataContract]
	public partial class MediaFile : BaseEntity, ITransient, IHasMedia
	{
		private ICollection<ProductMediaFile> _productMediaFiles;

		/// <summary>
		/// Gets or sets the picture binary
		/// </summary>
		[Obsolete("Use property MediaStorage instead")]
		public byte[] PictureBinary { get; set; }

        /// <summary>
        /// Gets or sets the picture mime type
        /// </summary>
		[DataMember]
		public string MimeType { get; set; }

		/// <summary>
		/// Gets or sets the picture width
		/// </summary>
		[DataMember]
		public int? Width { get; set; }

		/// <summary>
		/// Gets or sets the picture height
		/// </summary>
		[DataMember]
		public int? Height { get; set; }

		/// <summary>
		/// Gets or sets the SEO friendly name of the media file
		/// </summary>
		[DataMember]
		public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the picture is new
        /// </summary>
		[DataMember]
		public bool IsNew { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the entity transient/preliminary
		/// </summary>
		[DataMember]
		[Index("IX_UpdatedOn_IsTransient", 1)]
		public bool IsTransient { get; set; }

		/// <summary>
		/// Gets or sets the date and time of instance update
		/// </summary>
		[DataMember]
		[Index("IX_UpdatedOn_IsTransient", 0)]
		public DateTime UpdatedOnUtc { get; set; }

		/// <summary>
		/// Gets or sets the media storage identifier
		/// </summary>
		[DataMember]
		public int? MediaStorageId { get; set; }

		/// <summary>
		/// Gets or sets the media storage
		/// </summary>
		public virtual MediaStorage MediaStorage { get; set; }

		/// <summary>
		/// Gets or sets the product pictures
		/// </summary>
		[DataMember]
		public virtual ICollection<ProductMediaFile> ProductPictures
        {
			get { return _productMediaFiles ?? (_productMediaFiles = new HashSet<ProductMediaFile>()); }
            protected set { _productMediaFiles = value; }
        }
    }
}