﻿using System.ComponentModel.DataAnnotations;

namespace CommonMagic.DataAnnotations
{
	public static class Validation
	{
        /// <summary>
        /// Validates an object. Returns the object if it is valid otherwise Exception is thrown.
        /// </summary>
		public static T Validate<T>(this T value) where T : class
		{
			Validator.ValidateObject(value, new ValidationContext(value, null, null), validateAllProperties: true);
			return value;
		}

	}
}
