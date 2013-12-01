using System;
using FeatureSwitcher.Configuration.Specs.Contexts;
using FeatureSwitcher.Configuration.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Configuration.Specs
{
    public class When_application_configuration_does_not_ignore_errors : WithCleanUp
    {
        Establish ctx = () => Features.Are.ConfiguredBy.AppConfig();

        Because of = () => _exception = Catch.Exception(() => { var isEnabled = Feature<Simple>.Is().Enabled; });

        It should_throw_a_configuration_errors_exception = () => _exception.ShouldBeOfType<System.Configuration.ConfigurationErrorsException>();

        private static Exception _exception;
    }
}