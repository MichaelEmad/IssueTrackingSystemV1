using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace IssueTracking.Application.Helpers
{
    [DebuggerStepThrough]
    public static class Check
    {

        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>([NoEnumeration] T value, [InvokerParameterName][NotNull] string parameterName)
        {
            //#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(value, null))
            //#pragma warning restore IDE0041 // Use 'is null' check
            {
                NotEmpty(parameterName, nameof(parameterName));
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }
        [ContractAnnotation("value:null => halt")]
        public static string NotEmpty(string value, [InvokerParameterName][NotNull] string parameterName)
        {
            var exception = default(Exception);
            if (value is null)
            {
                exception = new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                exception = new ArgumentException(ArgumentIsEmpty(parameterName));
            }
            if (exception != null)
            {
                NotEmpty(parameterName, nameof(parameterName));
                throw exception;
            }
            return value;
        }

        private static string ArgumentIsEmpty(string argumentName)
        {
            return $"The string argument '{argumentName}' cannot be empty.";
        }

    }
}
