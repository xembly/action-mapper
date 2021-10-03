using FluentAssertions;
using Xunit;

namespace Xembly.ActionMapper.Tests
{
	public class ActionRegisterTests
	{
		[Fact]
		public void CanRegisterForAllProcesses()
		{
			var sut = ActionRegister.All(KeyModifiers.Alt, 0x01, e => { });
			sut.Identifier.Should().Be(Internals.ProcessIdentifier.None);
			sut.ProcessValue.Should().BeNullOrEmpty();
		}

		[Fact]
		public void CanRegisterForProcessById()
		{
			var sut = ActionRegister.ById(1, KeyModifiers.Alt, 0x01, e => { });
			sut.Identifier.Should().Be(Internals.ProcessIdentifier.Id);
			sut.ProcessValue.Should().Be("1");
		}

		[Fact]
		public void CanRegisterForProcessByName()
		{
			var sut = ActionRegister.ById(1, KeyModifiers.Alt, 0x01, e => { });
			sut.Identifier.Should().Be(Internals.ProcessIdentifier.Id);
			sut.ProcessValue.Should().Be("1");
		}

		[Fact]
		public void CanRegisterForProcessByWindowTitle()
		{
			var sut = ActionRegister.ById(1, KeyModifiers.Alt, 0x01, e => { });
			sut.Identifier.Should().Be(Internals.ProcessIdentifier.Id);
			sut.ProcessValue.Should().Be("1");
		}
	}
}
