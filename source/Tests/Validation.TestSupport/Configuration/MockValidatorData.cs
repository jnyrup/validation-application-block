// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.Configuration
{
    public class MockValidatorData : ValidatorData
    {
        public MockValidatorData()
        { }

        public MockValidatorData(string name, bool returnFailure)
            : base(name, typeof(MockValidator))
        {
            this.ReturnFailure = returnFailure;
        }

        private const string ReturnFailurePropertyName = "returnFailure";
        [ConfigurationProperty(ReturnFailurePropertyName, DefaultValue = false)]
        public bool ReturnFailure
        {
            get { return (bool)this[ReturnFailurePropertyName]; }
            set { this[ReturnFailurePropertyName] = value; }
        }

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new MockValidator(this.ReturnFailure);
        }
    }
}
