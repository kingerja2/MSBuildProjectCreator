﻿// Copyright (c) Jeff Kluge. All rights reserved.
//
// Licensed under the MIT license.

using Microsoft.Build.Evaluation;
using Shouldly;
using Xunit;

namespace Microsoft.Build.Utilities.ProjectCreation.UnitTests
{
    public class ImportTests : MSBuildTestBase
    {
        [Fact]
        public void ImportComplex()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import(
                    project: "7DAAB5E7D790429584923E4E1CBCA82A",
                    condition: "D18454A292794A87AF7FABC741228737",
                    sdk: "74DD86391F1448878DAC138A6B0BF706",
                    sdkVersion: "FA38CAE9A09044D0831FB10258F1D433")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""7DAAB5E7D790429584923E4E1CBCA82A"" Condition=""D18454A292794A87AF7FABC741228737"" Sdk=""74DD86391F1448878DAC138A6B0BF706"" Version=""FA38CAE9A09044D0831FB10258F1D433"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportOrder()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("5D3801D732C14BB2A8A2A8466B2DAD38")
                .Property("BCD8381CE5944323B3019379EBE55F5C", "36E81797987E4319A5BCE62F57ACE527")
                .Import("5E2A00F750CE4E14B793C51ACCA60F84")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""5D3801D732C14BB2A8A2A8466B2DAD38"" />
  <PropertyGroup>
    <BCD8381CE5944323B3019379EBE55F5C>36E81797987E4319A5BCE62F57ACE527</BCD8381CE5944323B3019379EBE55F5C>
  </PropertyGroup>
  <Import Project=""5E2A00F750CE4E14B793C51ACCA60F84"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportSdk()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("6D75CC8EE2FA40AA8A0DC43112A85A0C", sdk: "4E45E3BD92B941338162B69846B462AE")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""6D75CC8EE2FA40AA8A0DC43112A85A0C"" Sdk=""4E45E3BD92B941338162B69846B462AE"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportSdkAndVersion()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("8F66583869B84CE89D72FF6DAC8A3C66", sdk: "8E35FA0BABDB4488AA096CCF6C82C37A", sdkVersion: "E8835BFC0CF949BFB63AB3917294C41A")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""8F66583869B84CE89D72FF6DAC8A3C66"" Sdk=""8E35FA0BABDB4488AA096CCF6C82C37A"" Version=""E8835BFC0CF949BFB63AB3917294C41A"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportSimple()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("78885C0A95004569B281C097FE6A8252")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""78885C0A95004569B281C097FE6A8252"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportWithCondition()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("01C2CD160C4C4D3A81543D1003C3D750", condition: "541AB4AD8EE747818A54385CED55A50A")
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""01C2CD160C4C4D3A81543D1003C3D750"" Condition=""541AB4AD8EE747818A54385CED55A50A"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }

        [Fact]
        public void ImportWithConditionOnExistence()
        {
            ProjectCreator.Create(projectFileOptions: NewProjectFileOptions.None)
                .Import("150D2AEC5CA24ADEBB6A6FDBDE4AA26D", condition: "42649D00AF3644A1A23FACDC111F85D8", conditionOnExistence: true)
                .Xml
                .ShouldBe(
@"<Project>
  <Import Project=""150D2AEC5CA24ADEBB6A6FDBDE4AA26D"" Condition=""Exists('150D2AEC5CA24ADEBB6A6FDBDE4AA26D')"" />
</Project>",
                    StringCompareShould.IgnoreLineEndings);
        }
    }
}